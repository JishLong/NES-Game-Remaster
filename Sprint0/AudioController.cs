namespace Sprint0
{
    public class AudioController : IController
    {
        public void Update() 
        {
            AudioManager.GetInstance().Update();
        }
    }
}
