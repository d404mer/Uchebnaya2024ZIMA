using System;
using System.Collections.Generic;

namespace TEST.Models;

public partial class Character
{
    public long CharacterId { get; set; }

    public string? CharacterLogIn { get; set; }

    public string? CharacterName { get; set; }

    public string CharacterPassword { get; set; } = null!;
}
