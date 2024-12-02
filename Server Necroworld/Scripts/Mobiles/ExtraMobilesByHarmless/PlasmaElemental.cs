using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a plasma elemental corpse")]
    public class PlasmaElemental : BaseCreature
    {
        [Constructable]
        public PlasmaElemental()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "a plasma elemental";
            this.Body = 15;
            this.BaseSoundID = 838;

            this.SetStr(326, 355);
            this.SetDex(166, 185);
            this.SetInt(301, 325);
            Hue = 2063;

            this.SetHits(215, 240);

            this.SetDamage(17, 19);

            this.SetDamageType(ResistanceType.Physical, 15);
            this.SetDamageType(ResistanceType.Fire, 85);

            this.SetResistance(ResistanceType.Physical, 55, 65);
            this.SetResistance(ResistanceType.Fire, 60, 80);
            this.SetResistance(ResistanceType.Cold, 5, 10);
            this.SetResistance(ResistanceType.Poison, 60, 80);
            this.SetResistance(ResistanceType.Energy, 60, 80);

            this.SetSkill(SkillName.EvalInt, 60.1, 75.0);
            this.SetSkill(SkillName.Magery, 60.1, 75.0);
            this.SetSkill(SkillName.MagicResist, 75.2, 105.0);
            this.SetSkill(SkillName.Tactics, 80.1, 100.0);
            this.SetSkill(SkillName.Wrestling, 70.1, 100.0);

            this.Fame = 8500;
            this.Karma = -8500;

            this.VirtualArmor = 50;
            this.ControlSlots = 4;

            this.PackItem(new SulfurousAsh(30));

            this.AddItem(new LightSource());
        }

        public PlasmaElemental(Serial serial)
            : base(serial)
        {
        }

        public override double DispelDifficulty
        {
            get
            {
                return 117.5;
            }
        }
        public override double DispelFocus
        {
            get
            {
                return 45.0;
            }
        }
        public override bool BleedImmune
        {
            get
            {
                return true;
            }
        }
        public override int TreasureMapLevel
        {
            get
            {
                return 3;
            }
        }
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Rich);
            this.AddLoot(LootPack.Rich);
            this.AddLoot(LootPack.Gems);
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