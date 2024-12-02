using System;

namespace Server.Mobiles
{
    [CorpseName("a plague steed corpse")]
    [TypeAlias("Server.Mobiles.BrownHorse", "Server.Mobiles.DirtyHorse", "Server.Mobiles.GrayHorse", "Server.Mobiles.TanHorse")]
    public class Plaguesteed : BaseMount
    {
        private static readonly int[] m_IDs = new int[]
        {
            0xC8, 0x3E9F,
            0xE2, 0x3EA0,
            0xE4, 0x3EA1,
            0xCC, 0x3EA2
        };
        [Constructable]
        public Plaguesteed ()
            : this("a plague steed")
        {
        }

        [Constructable]
        public Plaguesteed (string name)
            : base(name, 0xE2, 0x3EA0, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            int random = Utility.Random(4);

            Body = 0x319;
            ItemID = 0x3EBB;
            BaseSoundID = 0xA8;
            Hue = 1067;

            SetStr(520, 540);
            SetDex(106, 200);
            SetInt(60, 100);

            SetHits(780, 904);
            SetMana(0);

            SetDamage(48, 55);

            SetDamageType(ResistanceType.Poison, 100);

            SetResistance(ResistanceType.Physical, 65, 70);
            SetResistance(ResistanceType.Fire, 65, 70);
            SetResistance(ResistanceType.Cold, 65, 70);
            SetResistance(ResistanceType.Energy, 65, 70);
            SetResistance(ResistanceType.Poison, 65, 70);

            SetSkill(SkillName.MagicResist, 65.1, 80.0);
            SetSkill(SkillName.Tactics, 99.3, 104.0);
            SetSkill(SkillName.Wrestling, 99.3, 104.0);

            Fame = 12000;
            Karma = 12000;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 89.1;
        }

        public Plaguesteed (Serial serial)
            : base(serial)
        {
        }

        public override int Meat
        {
            get
            {
                return 3;
            }
        }
        public override int Hides
        {
            get
            {
                return 100;
            }
        }
        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.FruitsAndVegies | FoodType.GrainsAndHay;
            }
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