// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item
using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

public class TastyFood : CookableFood
{
    [Constructable]
    public TastyFood()  : this(1)
    {
    }

    [Constructable]
    public TastyFood(int amount) : base(0x9F1, 10)
    {
        Name = "Tasty Food";
        Hue = 238;
        Weight = 0.1;
        Stackable = true;
        Amount = amount;
    }

    public TastyFood(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);

        writer.Write((int)0); // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);

        int version = reader.ReadInt();
    }

    public override Food Cook()
    {
        return new Ribs();
    }
}