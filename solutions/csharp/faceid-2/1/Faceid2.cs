public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object? other) => Equals(other as FacialFeatures);

    public bool Equals(FacialFeatures? other)
    {
        return other != null && this.EyeColor == other.EyeColor && this.PhiltrumWidth == other.PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}
public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object? other) => Equals(other as Identity);

    public bool Equals(Identity? other)
    {
        return other != null && this.Email == other.Email && this.FacialFeatures.Equals(other.FacialFeatures);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    HashSet<Identity> registeredUsers = new HashSet<Identity>();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);


    public bool IsAdmin(Identity identity)
    {
        return identity.Email == "admin@exerc.ism" && identity.FacialFeatures.Equals(new FacialFeatures("green", 0.9m));
    }

    public bool Register(Identity identity) => registeredUsers.Add(identity);

    public bool IsRegistered(Identity identity) => registeredUsers.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA == identityB;
}
