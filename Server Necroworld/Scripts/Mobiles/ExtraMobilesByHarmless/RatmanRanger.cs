using System;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
    [CorpseName("a ratman ranger corpse")]
    public class RatmanRanger : BaseCreature
    {
        [Constructable]
        public RatmanRanger()
            : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = NameList.RandomName("ratman");
            this.Body = 0x8E;
            this.BaseSoundID = 437;
            Hue = 2076;

            this.SetStr(246, 280);
            this.SetDex(201, 230);
            this.SetInt(216, 240);

            this.SetHits(88, 108);

            this.SetDamage(14, 30);

            this.SetDamageType(ResistanceType.Fire, 100);

            this.SetResistance(ResistanceType.Physical, 40, 55);
            this.SetResistance(ResistanceType.Fire, 10, 20);
            this.SetResistance(ResistanceType.Cold, 10, 20);
            this.SetResistance(ResistanceType.Poison, 10, 20);
            this.SetResistance(ResistanceType.Energy, 10, 20);

            this.SetSkill(SkillName.Anatomy, 80.2, 120.0);
            this.SetSkill(SkillName.Archery, 100.1, 110.0);
            this.SetSkill(SkillName.MagicResist, 75.1, 100.0);
            this.SetSkill(SkillName.Tactics, 70.1, 95.0);
            this.SetSkill(SkillName.Wrestling, 70.1, 95.0);

            this.Fame = 9500;
            this.Karma = -9500;

            this.VirtualArmor = 76;

            this.AddItem(new Bow());
            this.PackItem(new Arrow(Utility.RandomMinMax(120, 140)));
        }

        public RatmanRanger(Serial serial)
            : base(serial)
        {
        }

        public override InhumanSpeech SpeechType
        {
            get
            {
                return InhumanSpeech.Ratman;
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