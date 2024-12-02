using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a sunshine corpse")]
    public class Sunshine : BaseMount
    {
        [Constructable]
        public Sunshine()
            : this("a sunshine")
        {
        }

        [Constructable]
        public Sunshine(string name)
            : base(name, 0x74, 0x3EA7, AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            BaseSoundID = Core.AOS ? 0xA8 : 0x16A;

            SetStr(800, 850);
            SetDex(86, 105);
            SetInt(86, 125);

            SetHits(700, 900);

            SetDamage(36, 52);

            SetDamageType(ResistanceType.Physical, 40);
            SetDamageType(ResistanceType.Fire, 40);
            SetDamageType(ResistanceType.Energy, 20);

            SetResistance(ResistanceType.Physical, 65, 75);
            SetResistance(ResistanceType.Fire, 30, 60);
            SetResistance(ResistanceType.Cold, 30, 60);
            SetResistance(ResistanceType.Poison, 30, 60);
            SetResistance(ResistanceType.Energy, 30, 60);

            SetSkill(SkillName.EvalInt, 50.4, 90.0);
            SetSkill(SkillName.Magery, 50.4, 90.0);
            SetSkill(SkillName.MagicResist, 95.3, 120.0);
            SetSkill(SkillName.Tactics, 97.6, 120.0);
            SetSkill(SkillName.Wrestling, 80.5, 120.0);

            Fame = 14000;
            Karma = -14000;
            Hue = 1174;

            VirtualArmor = 60;

            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 115.1;


            switch (Utility.Random(4))
            {
                case 0:
                    {
                        BodyValue = 116;
                        ItemID = 16039;
                        break;
                    }
                case 1:
                    {
                        BodyValue = 177;
                        ItemID = 16053;
                        break;
                    }
                case 2:
                    {
                        BodyValue = 178;
                        ItemID = 16041;
                        break;
                    }
                case 3:
                    {
                        BodyValue = 179;
                        ItemID = 16055;
                        break;
                    }
            }

            if (Utility.RandomDouble() < 0.05)
                Hue = 2191;

            PackItem(new SulfurousAsh(Utility.RandomMinMax(3, 5)));
            SetSpecialAbility(SpecialAbility.DragonBreath);
        }

        public Sunshine(Serial serial)
            : base(serial)
        {
        }

        public override int Meat
        {
            get
            {
                return 5;
            }
        }
        public override int Hides
        {
            get
            {
                return 30;
            }
        }
        public override HideType HideType
        {
            get
            {
                return HideType.Barbed;
            }
        }
        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.Meat;
            }
        }
        public override bool CanAngerOnTame
        {
            get
            {
                return true;
            }
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich);
            AddLoot(LootPack.FilthyRich);
            AddLoot(LootPack.FilthyRich);
            AddLoot(LootPack.Average);

        }

        public override int GetAngerSound()
        {
            if (!Controlled)
                return 0x16A;

            return base.GetAngerSound();
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
