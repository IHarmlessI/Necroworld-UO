using System;

namespace Server.Mobiles
{
    [CorpseName("an icewind phoenix corpse")]
    public class IceWindPhoenix : BaseCreature, IAuraCreature
    {
        [Constructable]
        public IceWindPhoenix()
            : base(AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "an icewind phoenix";
            Body = 0x340;
            BaseSoundID = 0x8F;
            Hue = 1948;

            SetStr(804, 900);
            SetDex(202, 300);
            SetInt(604, 800);

            SetHits(940, 1083);

            SetDamage(30, 35);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Cold, 50);

            SetResistance(ResistanceType.Physical, 45, 55);
            SetResistance(ResistanceType.Cold, 60, 70);
            SetResistance(ResistanceType.Poison, 25, 35);
            SetResistance(ResistanceType.Energy, 40, 50);

            SetSkill(SkillName.EvalInt, 90.2, 100.0);
            SetSkill(SkillName.Magery, 90.2, 100.0);
            SetSkill(SkillName.Meditation, 75.1, 100.0);
            SetSkill(SkillName.MagicResist, 86.0, 135.0);
            SetSkill(SkillName.Tactics, 100.1, 120.0);
            SetSkill(SkillName.Wrestling, 100.1, 120.0);
            SetSkill(SkillName.DetectHidden, 70.0, 80.0);

            Fame = 20000;
            Karma = 0;

            VirtualArmor = 80;

            Tamable = true;
            ControlSlots = 5;
            MinTameSkill = 112.0;

            SetAreaEffect(AreaEffect.AuraDamage);
        }

        public IceWindPhoenix(Serial serial)
            : base(serial)
        {
        }

        public override bool CanAngerOnTame { get { return true; } }
        public override int Meat { get { return 1; } }
        public override MeatType MeatType { get { return MeatType.Bird; } }
        public override int Feathers { get { return 36; } }
        public override bool CanFly { get { return true; } }

        public void AuraEffect(Mobile m)
        {
            m.SendLocalizedMessage(1008112); // The intense cold is damaging you!
        }

        public override void OnAfterTame(Mobile tamer)
        {
            base.OnAfterTame(tamer);

            var profile = PetTrainingHelper.GetAbilityProfile(this);

            if (profile != null)
            {
                profile.RemoveAbility(AreaEffect.AuraDamage);
            }
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich);
            AddLoot(LootPack.UltraRich);
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
