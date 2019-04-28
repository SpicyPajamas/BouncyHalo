using Microsoft.Xna.Framework;

namespace BouncyHalo
{
    interface IEnemy
    {
        bool IsCollided(Rectangle body);
        void DoDamage(int damage);
        void flicker(Color color);
    }
}