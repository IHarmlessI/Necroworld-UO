using System;

namespace Server.Mobiles
{
    [CorpseName("an undead horse corpse")]
    [TypeAlias("Server.Mobiles.BrownHorse", "Server.Mobiles.DirtyHorse", "Server.Mobiles.GrayHorse", "Server.Mobiles.TanHorse")]
    public class Undeadsteed : BaseMount
    {
        private static readonly int[] m_IDs = new int[]
        {
            0xC8, 0x3E9F,
            0xE2, 0x3EA0,
            0xE4, 0x3EA1,
            0xCC, 0x3EA2
        };
        [Constructable]
        public Undeadsteed ()
            : this("an undead horse")
        {
        }

        [Constructable]
        public Undeadsteed (string name)
            : base(name, 0xE2, 0x3EA0, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            int random = Utility.Random(4);

            Body = 0x319;
            ItemID = 0x3EBB;
            BaseSoundID = 0xA8;

            SetStr(320, 340);
            SetDex(106, 200);
            SetInt(60, 100);

            SetHits(580, 604);
            SetMana(0);

            SetDamage(28, 35);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 85, 90);

            SetSkill(SkillName.MagicResist, 65.1, 70.0);
            SetSkill(SkillName.Tactics, 99.3, 94.0);
            SetSkill(SkillName.Wrestling, 99.3, 94.0);

            Fame = 10000;
            Karma = 10000;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 69.1;
        }

        public Undeadsteed (Serial serial)
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