namespace BasicExample
{
	using InControl;
	using UnityEngine;
    using UnityEngine.SceneManagement;

	public class BasicExample : MonoBehaviour
	{
        public int mySceneNum;
        public WaveMaker myWM;

        void Awake()
        {
            SceneManager.sceneLoaded += NewScene;
            DontDestroyOnLoad(this.gameObject);
        }

		void Update()
		{
            if (mySceneNum == 0)
            {
                JoinScreen();
            }
            else
            {
                GameScreen();
            }
		}

        void JoinScreen()
        {
            // Use last device which provided input.
            var inputDevice = InputManager.ActiveDevice;

            // Rotate target object with left stick.
            transform.Rotate(Vector3.down, 500.0f * Time.deltaTime * inputDevice.LeftStickX, Space.World);
            transform.Rotate(Vector3.right, 500.0f * Time.deltaTime * inputDevice.LeftStickY, Space.World);

            // Get two colors based on two action buttons.
            var color1 = inputDevice.Action1.IsPressed ? Color.red : Color.white;
            var color2 = inputDevice.Action2.IsPressed ? Color.green : Color.white;

            // Blend the two colors together to color the object.
            GetComponent<Renderer>().material.color = Color.Lerp(color1, color2, 0.5f);

            if (inputDevice.CommandIsPressed)
            {
                SceneManager.LoadScene(1);
            }
        }

        void GameScreen()
        {
            // Use last device which provided input.
            var inputDevice = InputManager.ActiveDevice;

            myWM.LSUD = inputDevice.LeftStickY;
            myWM.LSLR = inputDevice.LeftStickX;
            myWM.RSUD = inputDevice.RightStickY;
            myWM.RSLR = inputDevice.RightStickX;
        }

        void NewScene (Scene scene, LoadSceneMode mode)
        {
            mySceneNum = scene.buildIndex;
            if (mySceneNum != 0)
            {
                myWM = GameObject.Find("Waveform").GetComponent<WaveMaker>();
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
	}
}

