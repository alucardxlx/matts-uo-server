//Made By Jamze for use with a modified version of Murzin's Training Weapons.
using System;
using Server;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Guilds;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Misc
{
    public class TrainingWeaponDeed : Item // Create the item class which is derived from the base item class
    {
        [Constructable]
        public TrainingWeaponDeed()
            : base(0x14F0)
        {
            Weight = 1.0;
            Name = "A Deed for a Training Weapon.";
            Hue = 0x44;
        }

        public TrainingWeaponDeed(Serial serial)
            : base(serial)
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

        public override bool DisplayLootType { get { return false; } }

        public override void OnDoubleClick(Mobile from) // Override double click of the deed to call our target
        {
            if (!IsChildOf(from.Backpack)) // Make sure its in their pack
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
            else
            {
                from.SendGump(new TrainingWeaponGump(from, this));
            }
        }
    }
    public class TrainingWeaponGump : Gump
    {
        private Item m_Deed;
        private Mobile m_Mobile;

        public TrainingWeaponGump(Mobile from, Item deed)
            : base(20, 20)
        {
            m_Mobile = from;
            m_Deed = deed;
            {

                this.Closable = true;
                this.Disposable = true;
                this.Dragable = true;
                this.Resizable = false;
                this.AddPage(0);
                this.AddBackground(16, 16, 592, 464, 3600);
                this.AddLabel(190, 110, 95, @"Training weapons allow for faster skill gain");
                this.AddLabel(184, 63, 62, @"* Welcome to the Mystic Training Center *");
                this.AddLabel(222, 132, 17, @"And are blessed to prevent loss");
                this.AddLabel(193, 202, 53, @"Please choose a weapon to train with:");
                this.AddLabel(211, 253, 28, @"   A Bow for training Archery.");
                this.AddButton(195, 253, 4005, 4007, 1, GumpButtonType.Reply, 1);//Bow
                this.AddLabel(211, 269, 68, @"      (No Arrows Required)");
                this.AddLabel(211, 293, 28, @"   A Club for training Macing.");
                this.AddButton(195, 293, 4005, 4007, 2, GumpButtonType.Reply, 2);//Club
                this.AddLabel(211, 325, 28, @"   A Katana for training Swords.");
                this.AddButton(195, 325, 4005, 4007, 3, GumpButtonType.Reply, 3);//Katana
                this.AddLabel(213, 359, 28, @"   A Kryss for training Fencing.");
                this.AddButton(195, 359, 4005, 4007, 4, GumpButtonType.Reply, 4);//Kryss
                //Cancel Button
                this.AddButton(277, 444, 1028, 1027, 0, GumpButtonType.Reply, 0);
                this.AddImage(5, 5, 5500, 2028);
                this.AddImage(291, 394, 10450, 2028);
                this.AddImage(59, 402, 10462, 2028);
                this.AddImage(114, 402, 10462, 2028);
                this.AddImage(169, 402, 10462, 2028);
                this.AddImage(224, 402, 10462, 2028);
                this.AddImage(344, 402, 10462, 2028);
                this.AddImage(399, 402, 10462, 2028);
                this.AddImage(454, 402, 10462, 2028);
                this.AddImage(509, 402, 10462, 2028);
            }
        }

        
        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;
            
            switch (info.ButtonID)
            {
                case 0:
                    {
                        from.CloseGump(typeof(TrainingWeaponGump));
                        break;
                    }
                case 1:
                    {
                        Item item = new TrainingBow();
                        item.LootType = LootType.Blessed;
                        from.AddToBackpack(item);
                        from.CloseGump(typeof(TrainingWeaponGump));

                        m_Deed.Delete();

                        break;
                    }

                case 2:
                    {
                        Item item = new Trainingclub();
                        item.LootType = LootType.Blessed;
                        from.AddToBackpack(item);
                        from.CloseGump(typeof(TrainingWeaponGump));

                        m_Deed.Delete();

                        break;
                    }
                case 3:
                    {
                        Item item = new TrainingKatana();
                        item.LootType = LootType.Blessed;
                        from.AddToBackpack(item);
                        from.CloseGump(typeof(TrainingWeaponGump));

                        m_Deed.Delete();

                        break;
                    }

                case 4:
                    {
                        Item item = new TrainingKryss();
                        item.LootType = LootType.Blessed;
                        from.AddToBackpack(item);
                        from.CloseGump(typeof(TrainingWeaponGump));

                        m_Deed.Delete();

                        break;
                    }
                
            }
        }
    }
}
