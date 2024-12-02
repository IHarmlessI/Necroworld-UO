using System;
using Server.Factions;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an ogre mage corpse")]
    public class OgreMage : BaseCreature
    {
        [Constructable]
        public OgreMage()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "an ogre mage";
            this.Body = 83;
            this.BaseSoundID = 427;
            Hue = 1963;

            this.SetStr(967, 1045);
            this.SetDex(66, 75);
            this.SetInt(146, 170);

            this.SetHits(676, 852);

            this.SetDamage(30, 35);

            this.SetDamageType(ResistanceType.Physical, 60);
            this.SetDamageType(ResistanceType.Fire, 40);

            this.SetResistance(ResistanceType.Physical, 55, 75);
            this.SetResistance(ResistanceType.Fire, 60, 80);
            this.SetResistance(ResistanceType.Cold, 30, 40);
            this.SetResistance(ResistanceType.Poison, 40, 50);
            this.SetResistance(ResistanceType.Energy, 40, 50);

            this.SetSkill(SkillName.MagicResist, 125.1, 140.0);
            this.SetSkill(SkillName.Tactics, 90.1, 100.0);
            this.SetSkill(SkillName.Wrestling, 90.1, 100.0);

            this.Fame = 18000;
            this.Karma = -18000;

            this.VirtualArmor = 70;
            SetSpecialAbility(SpecialAbility.DragonBreath);

            this.PackItem(new Club());
        }

        public OgreMage(Serial serial)
            : base(serial)
        {
        }

        public override Faction FactionAllegiance
        {
            get
            {
                return Minax.Instance;
            }
        }
        public override Ethics.Ethic EthicAllegiance
        {
            get
            {
                return Ethics.Ethic.Evil;
            }
        }
        public override bool CanRummageCorpses
        {
            get
            {
                return true;
            }
        }
        public override Poison PoisonImmune
        {
            get
            {
                return Poison.Regular;
            }
        }
        public override int TreasureMapLevel
        {
            get
            {
                return 4;
            }
        }
        public override int Meat
        {
            get
            {
                return 2;
            }
        }
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.UltraRich, 2);
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