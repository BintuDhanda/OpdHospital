public static class UsernameHelper
{
    public static async Task<string> GenerateUniqueUsernameAsync(
        string roleName,
        Func<string, Task<bool>> isUsernameExists)
    {
        if (string.IsNullOrWhiteSpace(roleName))
            throw new ArgumentException("Role name is required");

        // Role-based prefix
        string prefix = roleName.ToLower() switch
        {
            "doctor" => "dr",
            "hospital" => "hosp",
            "sales" => "sales",
            _ => "user"
        };

        const int maxAttempts = 30;
        var random = new Random();

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            var suffix = random.Next(10000, 99999);
            var username = $"{prefix}-{suffix}";

            if (!await isUsernameExists(username))
                return username;
        }

        throw new Exception("Unable to generate unique username after multiple attempts");
    }
}
