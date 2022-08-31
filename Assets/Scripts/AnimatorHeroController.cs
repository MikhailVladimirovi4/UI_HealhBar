using UnityEngine;

public class AnimatorHeroController : MonoBehaviour
{
    public static class Params
    {
        public const string Die = nameof(Die);
    }

    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string Die = nameof(Die);
    }
}
