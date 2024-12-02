using System;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
    [CorpseName("a lizardman archer corpse")]
    public class LizardmanArcher : BaseCreature
    {
        [Constructable]
        public LizardmanArcher()
            : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = ("lizardman archer");
            this.Body = Utility.RandomList(35, 36);
            this.BaseSoundID = 417;
            Hue = 2070;

            this.SetStr(146, 180);
            this.SetDex(101, 130);
            this.SetInt(116, 140);

            this.SetHits(88, 108);

            this.SetDamage(14, 30);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 40, 45);
            this.SetResistance(ResistanceType.Fire, 10, 20);
            this.SetResistance(ResistanceType.Cold, 10, 20);
            this.SetResistance(ResistanceType.Poison, 10, 20);
            this.SetResistance(ResistanceType.Energy, 10, 20);

            this.SetSkill(SkillName.Anatomy, 80.2, 100.0);
            this.SetSkill(SkillName.Archery, 90.1, 100.0);
            this.SetSkill(SkillName.MagicResist, 75.1, 100.0);
            this.SetSkill(SkillName.Tactics, 70.1, 95.0);
            this.SetSkill(SkillName.Wrestling, 70.1, 95.0);

            this.Fame = 9500;
            this.Karma = -9500;

            this.VirtualArmor = 56;

            this.AddItem(new Bow());
            this.PackItem(new Arrow(Utility.RandomMinMax(80, 90)));
        }

        public LizardmanArcher(Serial serial)
            : base(serial)
        {
        }

        public override InhumanSpeech SpeechType
        {
            get
            {
                return InhumanSpeech.Lizardman;
            }
        }
        public override bool CanRummageCorpses
        {
            get
            {
                return true;
            }
        }
        public override int Hides
        {
            get
            {
                return 18;
            }
        }
        public override HideType HideType
        {
            get
            {
                return HideType.Spined;
            }
        }
        public override void GenerateLoot()
        {
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