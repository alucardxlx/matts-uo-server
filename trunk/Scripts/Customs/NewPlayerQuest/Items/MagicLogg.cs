// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item
using System;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{
    [FlipableAttribute(0x1BD7, 0x1BDA)]
    public class MagicLogg : Item
    {
        [Constructable]
        public MagicLogg() : this(1)
        {
        }

        [Constructable]
        public MagicLogg(int amount)
            : base(0x1BD7)
        {
            Stackable = true;
            Name = "Magic Log";
            Hue = 33;
            Weight = 0.1;
            Amount = amount;
        }

        public MagicLogg(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
