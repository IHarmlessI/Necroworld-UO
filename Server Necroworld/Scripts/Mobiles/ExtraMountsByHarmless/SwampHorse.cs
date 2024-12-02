using System;

namespace Server.Mobiles
{
    [CorpseName("a Swamp horse corpse")]
    [TypeAlias("Server.Mobiles.BrownHorse", "Server.Mobiles.DirtyHorse", "Server.Mobiles.GrayHorse", "Server.Mobiles.TanHorse")]
    public class Swamphorse : BaseMount
    {
        private static readonly int[] m_IDs = new int[]
        {
            0xC8, 0x3E9F,
            0xE2, 0x3EA0,
            0xE4, 0x3EA1,
            0xCC, 0x3EA2
        };
        [Constructable]
        public Swamphorse ()
            : this("a Swamp horse")
        {
        }

        [Constructable]
        public Swamphorse (string name)
            : base(name, 0xE2, 0x3EA0, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            int random = Utility.Random(4);

            Body = m_IDs[random * 2];
            ItemID = m_IDs[random * 2 + 1];
            BaseSoundID = 0xA8;

            SetStr(270, 310);
            SetDex(106, 200);
            SetInt(80, 120);

            SetHits(1400, 1730);
            SetMana(0);
            Hue = 1189;

            SetDamage(25, 30);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 75, 80);

            SetSkill(SkillName.MagicResist, 65.1, 80.0);
            SetSkill(SkillName.Tactics, 99.3, 94.0);
            SetSkill(SkillName.Wrestling, 99.3, 94.0);

            Fame = 3000;
            Karma = 3000;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 79.1;
        }

        public Swamphorse (Serial serial)
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