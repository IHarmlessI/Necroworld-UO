using System;
using System.Linq;
using System.Collections;

using Server.Items;
using Server.Spells;

namespace Server.Mobiles
{
    [CorpseName("a succubus corpse")]
    public class DemonicSuccubus : BaseCreature
    {
        [Constructable]
        public DemonicSuccubus()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a demonic succubus";
            Body = 149;
            BaseSoundID = 0x4B0;
            Hue = 2235;

            SetStr(815, 840);
            SetDex(180, 240);
            SetInt(733, 800);

            SetHits(619, 705);

            SetDamage(28, 38);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Fire, 50);

            SetResistance(ResistanceType.Physical, 80, 90);
            SetResistance(ResistanceType.Fire, 70, 80);
            SetResistance(ResistanceType.Cold, 40, 50);
            SetResistance(ResistanceType.Poison, 50, 60);
            SetResistance(ResistanceType.Energy, 50, 60);

            SetSkill(SkillName.EvalInt, 90.1, 120.0);
            SetSkill(SkillName.Magery, 99.1, 120.0);
            SetSkill(SkillName.Meditation, 90.1, 120.0);
            SetSkill(SkillName.MagicResist, 100.5, 150.0);
            SetSkill(SkillName.Tactics, 90.1, 110.0);
            SetSkill(SkillName.Wrestling, 90.1, 100.0);

            Fame = 34000;
            Karma = -34000;

            VirtualArmor = 100;

            SetSpecialAbility(SpecialAbility.LifeDrain);
        }

        public DemonicSuccubus(Serial serial)
            : base(serial)
        {
        }

        public override int Meat
        {
            get
            {
                return 1;
            }
        }
        public override int TreasureMapLevel
        {
            get
            {
                return 6;
            }
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 4);
            AddLoot(LootPack.MedScrolls, 2);
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
