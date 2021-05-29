using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMapNavigator : MonoBehaviour
{
	public ItemsCollected GemsCollected;
	public BezierCurve CurrentPath;
	public float Duration = 2f;

	private World WorldPaths;
	private BezierCurve PathToUnlock;
	private int CurrentLevelNumber;
	private LevelInfo CurrentLevelNode;
	private int DirectionValue;
	private List<BezierCurve> AvailablePaths;
	private int Default;
	private float progress;
	private float PositioningSpoed = 5f;
	private bool goingForward;
	private bool CanMove;
	private bool Entering;
	private PlayerControls PlayerControls;
	private Rigidbody RB;
	private Vector3 position;
	private Vector2 DirectionInput;
	private Vector2 Direction;

    private void OnEnable()
    {
		if(RB == null)
        {
			RB = GetComponent<Rigidbody>();
        }

		if(PlayerControls == null)
        {
			PlayerControls = new PlayerControls();
			PlayerControls.WorldMap.Movement.performed += i => DirectionInput = i.ReadValue<Vector2>();
			PlayerControls.WorldMap.Confirm.performed += i => ConfirmLevelSelect();
        }
		PlayerControls.Enable();
		if (GameManager.Instance.WorldMapLocation.WorldMapPosition != new Vector3(0,0,0))
        {
			transform.localPosition = GameManager.Instance.WorldMapLocation.WorldMapPosition;
			UnlockLevel();
        }
		else
		{
			PositionPlayerOnCurve();
		}
		RB.constraints = RigidbodyConstraints.FreezePositionY;
	}

	private void OnDisable()
	{
		PlayerControls.Disable();
	}

	private void Update()
	{
		if (goingForward)
		{
			if (progress < 1f)
			{
				progress += Time.deltaTime / Duration;
				PositionPlayerOnCurve();
			}
			else
			{
				progress = 1f;
			}
		}
		else
		{	
			if (progress > 0)
			{
				progress -= Time.deltaTime / Duration;
				PositionPlayerOnCurve();
			}
            else
            {
				progress = 0;
			}
		}
        if (GameManager.Instance.CanMove)
        {
			if (CanMove)
			{
				Move();
			}
		}
	}

	private void UnlockLevel()
    {
		RaycastHit Hit;
		if (Physics.Raycast(transform.localPosition, Vector3.down, out Hit, 1f))
		{
			if (Hit.collider.GetComponent<LevelInfo>())
			{
				LevelInfo Level = Hit.collider.GetComponent<LevelInfo>();
				BezierCurve UnlockPath = Level.ConnectedPaths[Default];
				if (GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked.Contains(UnlockPath))
				{
					UnlockPath.Unlocked = GameManager.Instance.WorldMapLocation.PathsInWorldUnlocked[GameManager.Instance.WorldMapLocation.PathToUnlock] = true;
				}
			}
		}
	}

	private void ConfirmLevelSelect()
    {
		CanMove = false;

		if(PathToUnlock != null)
        {
			if (WorldPaths.PathsInWorld.Contains(PathToUnlock))
			{
				int UnlockPath = WorldPaths.PathsInWorld.IndexOf(PathToUnlock);
				GameManager.Instance.WorldMapLocation.PathToUnlock = UnlockPath;
			}
		}
		GameManager.Instance.WorldMapLocation.WorldMapPosition = transform.localPosition;
		GameManager.Instance.Scene = SceneManager.GetActiveScene().buildIndex + CurrentLevelNumber;
		GameManager.Instance.SaveGame();
		GameManager.Instance.StartCoroutine(GameManager.Instance.FadingEffect(null));
    }

	private void PositionPlayerOnCurve()
    {
		if (CurrentPath != null)
		{
			position = CurrentPath.GetPoint(progress);
			transform.position = position;
			LookDirection(transform);
		}
	}

	private IEnumerator PositionPlayerOnLevel(Transform LevelPosition)
    {
		goingForward = false;
		progress = 0;

        if (Entering)
        {
			while (transform.localPosition != LevelPosition.position)
			{
				transform.localPosition = Vector3.MoveTowards(transform.localPosition, LevelPosition.position, Time.deltaTime * PositioningSpoed);
				yield return null;
			}
			while(transform.localRotation != Quaternion.Euler(0, 0, 0))
			{
				transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * PositioningSpoed);
				yield return null;
			}
			transform.localRotation = Quaternion.identity;
			CanMove = true;
		}
	}

	public void LookDirection(Transform LevelPosition)
    {
		if (goingForward)
		{
			transform.LookAt(position - CurrentPath.GetDirection(progress));
		}
		else
		{
			transform.LookAt(position + CurrentPath.GetDirection(progress));
		}
	}

	private void Move()
    {
		Direction = new Vector2(DirectionInput.x, DirectionInput.y);
		if(Direction.x == -1)
        {
			foreach (var i in CurrentLevelNode.MoveOptions)
			{
				if (i == LevelInfo.Connected.left)
				{
					DirectionValue = Convert.ToInt32(i);
					if (AvailablePaths.Count == 1)
					{
                        if (AvailablePaths[Default].Unlocked)
                        {
							CurrentPath = AvailablePaths[Default];
							CanMove = false;
							goingForward = true;
							Entering = false;
						}
					}
					else
					{
                        if (AvailablePaths[DirectionValue].Unlocked)
                        {
							CurrentPath = AvailablePaths[DirectionValue];
							CanMove = false;
							goingForward = true;
							Entering = false;
						}
					}
				}
			}
		}
		if(Direction.x == 1)
        {
			foreach (LevelInfo.Connected i in CurrentLevelNode.MoveOptions)
			{
				if (i == LevelInfo.Connected.right)
				{
					DirectionValue = Convert.ToInt32(i);
					if (AvailablePaths.Count == 1)
					{
						CurrentPath = AvailablePaths[Default];
						CanMove = false;
						progress = 1f;
						goingForward = false;
						Entering = false;
					}
					else
					{
						CurrentPath = AvailablePaths[DirectionValue];
						CanMove = false;
						progress = 1f;
						goingForward = false;
						Entering = false;
					}
				}
			}
		}
		if(Direction.y == -1)
        {
			foreach (LevelInfo.Connected i in CurrentLevelNode.MoveOptions)
			{
				if (i == LevelInfo.Connected.down)
				{
					DirectionValue = Convert.ToInt32(i);
					if (AvailablePaths.Count == 1)
					{
						if (AvailablePaths[Default].Unlocked)
						{
							CurrentPath = AvailablePaths[Default];
							CanMove = false;
							progress = 1f;
							goingForward = false;
							Entering = false;
						}
					}
					else
					{
						if (AvailablePaths[DirectionValue].Unlocked)
						{
							CurrentPath = AvailablePaths[DirectionValue];
							CanMove = false;
							progress = 1f;
							goingForward = false;
							Entering = false;
						}
					}
				}
			}
		}
		if(Direction.y == 1)
        {
			foreach(LevelInfo.Connected i in CurrentLevelNode.MoveOptions)
            {
				if(i == LevelInfo.Connected.up)
                {
					DirectionValue = Convert.ToInt32(i);
					if (AvailablePaths.Count == 1)
					{
						if (AvailablePaths[Default].Unlocked)
						{
							CurrentPath = AvailablePaths[Default];
							CanMove = false;
							goingForward = true;
							Entering = false;
						}
					}
					else
					{
						if (AvailablePaths[DirectionValue].Unlocked)
						{
							CurrentPath = AvailablePaths[DirectionValue];
							CanMove = false;
							goingForward = true;
							Entering = false;
						}
					}
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LevelInfo>())
        {
			LevelInfo Level = other.GetComponent<LevelInfo>();
			if(WorldPaths == null)
            {
				WorldPaths = Level.GetComponentInParent<World>();
            }
			AvailablePaths = Level.ConnectedPaths;
			Entering = true;
			CurrentLevelNode = Level;
			CurrentLevelNumber = Level.Level;
			PathToUnlock = Level.PathToUnlock;
			Level.DisplayLevelInfo(GemsCollected);
			StartCoroutine(PositionPlayerOnLevel(CurrentLevelNode.gameObject.transform));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<LevelInfo>())
        {
			LevelInfo Level = other.GetComponent<LevelInfo>();
			Level.HideDisplayInfo();
        }
    }
}
