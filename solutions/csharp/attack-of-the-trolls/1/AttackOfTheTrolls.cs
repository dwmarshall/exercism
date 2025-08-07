enum AccountType
{
    Guest,
    User,
    Moderator,
}

[Flags]
enum Permission
{
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4,
    All = 7,
}

static class Permissions
{
    static Dictionary<AccountType, Permission> defaultPerms = new Dictionary<AccountType, Permission>
    {
        {AccountType.Guest, Permission.Read},
        {AccountType.User, Permission.Read | Permission.Write},
        {AccountType.Moderator, Permission.All },
    };
    public static Permission Default(AccountType accountType)
    {
        if (defaultPerms.ContainsKey(accountType))
        {
            return defaultPerms[accountType];
        }
        else
        {
            return Permission.None;
        }

    }
    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke) => current & ~revoke;

    public static bool Check(Permission current, Permission check) => (check & current) == check;
}
