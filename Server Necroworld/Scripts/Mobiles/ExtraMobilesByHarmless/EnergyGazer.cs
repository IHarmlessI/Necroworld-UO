using System;

namespace Server.Mobiles
{
    [CorpseName("an energy gazer corpse")]
    public class EnergyGazer : BaseCreature
    {
        [Constructable]
        public EnergyGazer()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "an energy gazer";
            this.Body = 22;
            this.BaseSoundID = 377;
            Hue = 2097;

            this.SetStr(496, 525);
            this.SetDex(116, 125);
            this.SetInt(391, 485);

            this.SetHits(378, 495);

            this.SetDamage(15, 26);

            this.SetDamageType(ResistanceType.Energy, 100);

            this.SetResistance(ResistanceType.Physical, 65, 75);
            this.SetResistance(ResistanceType.Fire, 60, 70);
            this.SetResistance(ResistanceType.Cold, 50, 70);
            this.SetResistance(ResistanceType.Poison, 50, 70);
            this.SetResistance(ResistanceType.Energy, 50, 70);

            this.SetSkill(SkillName.Anatomy, 82.0, 100.0);
            this.SetSkill(SkillName.EvalInt, 90.1, 100.0);
            this.SetSkill(SkillName.Magery, 90.1, 100.0);
            this.SetSkill(SkillName.MagicResist, 115.1, 130.0);
            this.SetSkill(SkillName.Tactics, 80.1, 100.0);
            this.SetSkill(SkillName.Wrestling, 80.1, 100.0);

            this.Fame = 14500;
            this.Karma = -14500;

            this.VirtualArmor = 70;
        }

        public EnergyGazer(Serial serial)
            : base(serial)
        {
        }

        public override int TreasureMapLevel
        {
            get
            {
                return Core.AOS ? 4 : 0;
            }
        }
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.FilthyRich);
            this.AddLoot(LootPack.FilthyRich);
            this.AddLoot(LootPack.UltraRich);
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