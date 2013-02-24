// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest.  Melee Item
using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{
    public class MageBag : Item
    {
        [Constructable]
        public MageBag() : this(1)
        {
        }

        [Constructable]
        public MageBag(int amount) : base(0x3192)
        {
            Name = "Mage bag";
            Stackable = true;
            Amount = amount;
            Hue = 68;
        }
        public override void OnDoubleClick(Mobile m)
        {
            m.SendMessage("You feel you should not meedle in mage affairs.");
        }

        public MageBag(Serial serial) : base(serial)
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
    }
}
