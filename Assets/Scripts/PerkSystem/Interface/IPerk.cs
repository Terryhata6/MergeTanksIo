public interface IPerk
{
    void Activate (PlayerView ownPlayer);
    void Deactivate (PlayerView ownPlayer);

    void Activate (Shooter ownShoot);
    void Deactivate (Shooter ownShoot);
}