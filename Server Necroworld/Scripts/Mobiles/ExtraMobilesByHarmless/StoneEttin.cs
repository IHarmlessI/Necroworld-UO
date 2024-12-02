using System;

namespace Server.Mobiles
{
    [CorpseName("a stone ettins corpse")]
    public class StoneEttin : BaseCreature
    {
        [Constructable]
        public StoneEttin()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "a stone ettin";
            this.Body = 18;
            this.BaseSoundID = 367;
            Hue = 1935;

            this.SetStr(336, 365);
            this.SetDex(106, 135);
            this.SetInt(66, 94);

            this.SetHits(82, 99);

            this.SetDamage(17, 37);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 55, 70);
            this.SetResistance(ResistanceType.Fire, 15, 50);
            this.SetResistance(ResistanceType.Cold, 40, 50);
            this.SetResistance(ResistanceType.Poison, 15, 50);
            this.SetResistance(ResistanceType.Energy, 15, 50);

            this.SetSkill(SkillName.MagicResist, 50.1, 65.0);
            this.SetSkill(SkillName.Tactics, 70.1, 90.0);
            this.SetSkill(SkillName.Wrestling, 50.1, 60.0);

            this.Fame = 6000;
            this.Karma = -6000;

            this.VirtualArmor = 72;
        }

        public StoneEttin(Serial serial)
            : base(serial)
        {
        }

        public override bool CanRummageCorpses
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
                return 2;
            }
        }
        public override int Meat
        {
            get
            {
                return 4;
            }
        }
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Meager);
            this.AddLoot(LootPack.Average);
            this.AddLoot(LootPack.Rich);
            this.AddLoot(LootPack.Potions);
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