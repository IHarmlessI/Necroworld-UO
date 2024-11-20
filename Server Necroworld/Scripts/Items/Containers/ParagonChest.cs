using System;

namespace Server.Items
{
    [Flipable]
    public class ParagonChest : LockableContainer
    {
        private static readonly int[] m_ItemIDs = new int[]
        {
            0x9AB, 0xE40, 0xE41, 0xE7C
        };
        private static readonly int[] m_Hues = new int[]
        {
            0x0, 0x455, 0x47E, 0x89F, 0x8A5, 0x8AB,
            0x966, 0x96D, 0x972, 0x973, 0x979
        };
        private string m_Name;
        [Constructable]
        public ParagonChest(string name, int level)
            : base(Utility.RandomList(m_ItemIDs))
        {
            m_Name = name;
            Hue = Utility.RandomList(m_Hues);
            Fill(level);
        }

        public ParagonChest(Serial serial)
            : base(serial)
        {
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, 1063449, m_Name);
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add(1063449, m_Name);
        }

        public void Flip()
        {
            switch ( ItemID )
            {
                case 0x9AB :
                    ItemID = 0xE7C;
                    break;
                case 0xE7C :
                    ItemID = 0x9AB;
                    break;
                case 0xE40 :
                    ItemID = 0xE41;
                    break;
                case 0xE41 :
                    ItemID = 0xE40;
                    break;
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_Name);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Name = Utility.Intern(reader.ReadString());
        }

        private static void GetRandomAOSStats(out int attributeCount, out int min, out int max)
        {
            int rnd = Utility.Random(20);

            if (rnd < 4)
            {
                attributeCount = Utility.RandomMinMax(3, 6);
                min = 50;
                max = 90;
            }
            else if (rnd < 8)
            {
                attributeCount = Utility.RandomMinMax(3, 5);
                min = 30;
                max = 80;
            }
            else if (rnd < 12)
            {
                attributeCount = Utility.RandomMinMax(2, 4);
                min = 30;
                max = 70;
            }
            else if (rnd < 16)
            {
                attributeCount = Utility.RandomMinMax(2, 3);
                min = 20;
                max = 60;
            }
            else
            {
                attributeCount = 2;
                min = 10;
                max = 50;
            }
        }

        private void Fill(int level)
        {
            TrapType = TrapType.ExplosionTrap;
            TrapPower = level * 25;
            TrapLevel = level;
            Locked = true;

            switch ( level )
            {
                case 1:
                    RequiredSkill = 15;
                    break;
                case 2:
                    RequiredSkill = 35;
                    break;
                case 3:
                    RequiredSkill = 45;
                    break;
                case 4:
                    RequiredSkill = 55;
                    break;
                case 5:
                    RequiredSkill = 75;
                    break;
                case 6:
                    RequiredSkill = 90;
                    break;
            }

            LockLevel = RequiredSkill - 10;
            MaxLockLevel = RequiredSkill + 40;

            DropItem(new Gold(level * Utility.RandomMinMax(150, 200)));
            DropItem(new Gold(level * Utility.RandomMinMax(150, 200)));
            DropItem(new Gold(level * Utility.RandomMinMax(150, 200)));

            for (int i = 0; i < level+2; ++i)
                DropItem(Loot.RandomScroll(0, 63, SpellbookType.Regular));

            for (int i = 0; i < level * 3; ++i)
            {
                Item item;

                if (Core.AOS)
                    item = Loot.RandomArmorOrShieldOrWeaponOrJewelry();
                else
                    item = Loot.RandomArmorOrShieldOrWeapon();

                if (item != null && Core.HS && RandomItemGenerator.Enabled)
                {
                    int min, max;
                    TreasureMapChest.GetRandomItemStat(out min, out max);

                    RunicReforging.GenerateRandomItem(item, 0, min, max);

                    DropItem(item);
                    continue;
                }

                if (item is BaseWeapon)
                {
                    BaseWeapon weapon = (BaseWeapon)item;

                    if (Core.AOS)
                    {
                        int attributeCount;
                        int min, max;

                        GetRandomAOSStats(out attributeCount, out min, out max);

                        BaseRunicTool.ApplyAttributesTo(weapon, attributeCount, min, max);
                    }
                    else
                    {
                        weapon.DamageLevel = (WeaponDamageLevel)Utility.Random(6);
                        weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random(6);
                        weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random(6);
                    }

                    DropItem(item);
                }
                else if (item is BaseArmor)
                {
                    BaseArmor armor = (BaseArmor)item;

                    if (Core.AOS)
                    {
                        int attributeCount;
                        int min, max;

                        GetRandomAOSStats(out attributeCount, out min, out max);

                        BaseRunicTool.ApplyAttributesTo(armor, attributeCount, min, max);
                    }
                    else
                    {
                        armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random(6);
                        armor.Durability = (ArmorDurabilityLevel)Utility.Random(6);
                    }

                    DropItem(item);
                }
                else if (item is BaseHat)
                {
                    BaseHat hat = (BaseHat)item;

                    if (Core.AOS)
                    {
                        int attributeCount;
                        int min, max;

                        GetRandomAOSStats(out attributeCount, out min, out max);

                        BaseRunicTool.ApplyAttributesTo(hat, attributeCount, min, max);
                    }

                    DropItem(item);
                }
                else if (item is BaseJewel)
                {
                    int attributeCount;
                    int min, max;

                    GetRandomAOSStats(out attributeCount, out min, out max);

                    BaseRunicTool.ApplyAttributesTo((BaseJewel)item, attributeCount, min, max);

                    DropItem(item);
                }
            }

            for (int i = 0; i < level+2; i++)
            {
                Item item = Loot.RandomRareGem();
                DropItem(item);
            }

            DropItem(new TreasureMap(TreasureMapInfo.ConvertLevel(level + 1), (Siege.SiegeShard ?  Map.Felucca : Utility.RandomBool() ? Map.Felucca : Map.Trammel)));
        }
    }
}
