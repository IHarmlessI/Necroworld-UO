using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a ghost wolf corpse")]
    public class GhostWolf : BaseMount
    {
        public override double HealChance { get { return 1.0; } }

        [Constructable]
        public GhostWolf()
            : this("a ghost wolf")
        {
        }

        [Constructable]
        public GhostWolf(string name)
            : base(name, 277, 0x3E91, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            double chance = Utility.RandomDouble() * 23301;

            Hue = 1159;

            SetStr(1400, 1425);
            SetDex(350, 370);
            SetInt(450, 485);

            SetHits(1310, 1475);

            SetDamage(51, 58);

            SetDamageType(ResistanceType.Physical, 0);
            SetDamageType(ResistanceType.Cold, 50);
            SetDamageType(ResistanceType.Energy, 50);

            SetResistance(ResistanceType.Physical, 50, 85);
            SetResistance(ResistanceType.Fire, 25, 85);
            SetResistance(ResistanceType.Cold, 70, 85);
            SetResistance(ResistanceType.Poison, 30, 80);
            SetResistance(ResistanceType.Energy, 70, 85);

            SetSkill(SkillName.Wrestling, 90.1, 116.8);
            SetSkill(SkillName.Tactics, 90.3, 119.3);
            SetSkill(SkillName.MagicResist, 75.3, 110.0);
            SetSkill(SkillName.Anatomy, 65.5, 119.4);
            SetSkill(SkillName.Healing, 72.2, 118.9);

            Fame = 15000;  //Guessing here
            Karma = 15000;  //Guessing here

            Tamable = true;
            ControlSlots = 5;
            MinTameSkill = 108.1;

            PackGold(1700, 2800);

            SetWeaponAbility(WeaponAbility.BleedAttack);
        }

        public GhostWolf(Serial serial)
            : base(serial)
        {
        }

        public override int TreasureMapLevel
        {
            get { return 6; }
        }

        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.FruitsAndVegies;
            }
        }
        public override bool CanAngerOnTame
        {
            get
            {
                return true;
            }
        }
        public override bool StatLossAfterTame
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
                return 10;
            }
        }
        public override int Meat
        {
            get
            {
                return 3;
            }
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.AosFilthyRich, 9);
        }

        public override void OnAfterTame(Mobile tamer)
        {
            if (Owners.Count == 0 && PetTrainingHelper.Enabled)
            {
                if (RawStr > 0)
                    RawStr = (int)Math.Max(1, RawStr * 0.8);

                if (RawDex > 0)
                    RawDex = (int)Math.Max(1, RawDex * 0.8);

                if (HitsMaxSeed > 0)
                    HitsMaxSeed = (int)Math.Max(1, HitsMaxSeed * 0.8);

                Hits = Math.Min(HitsMaxSeed, Hits);
                Stam = Math.Min(RawDex, Stam);
            }
            else
            {
                base.OnAfterTame(tamer);
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.Race != Race.Elf && from == ControlMaster && from.IsPlayer())
            {
                Item pads = from.FindItemOnLayer(Layer.Shoes);

                if (pads is PadsOfTheCuSidhe)
                    from.SendLocalizedMessage(1071981); // Your boots allow you to mount the Cu Sidhe.
                else
                {
                    from.SendLocalizedMessage(1072203); // Only Elves may use 
                    return;
                }
            }

            base.OnDoubleClick(from);
        }

        public override int GetIdleSound()
        {
            return 0x577;
        }

        public override int GetAttackSound()
        {
            return 0x576;
        }

        public override int GetAngerSound()
        {
            return 0x578;
        }

        public override int GetHurtSound()
        {
            return 0x576;
        }

        public override int GetDeathSound()
        {
            return 0x579;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)3); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version < 3 && Controlled && RawStr >= 1200 && ControlSlots == ControlSlotsMin)
            {
                Server.SkillHandlers.AnimalTaming.ScaleStats(this, 0.8);
            }

            if (version < 1 && Name == "a ghost wolf")
                Name = "a ghost wolf";

            if (version == 1)
            {
                SetWeaponAbility(WeaponAbility.BleedAttack);
            }
        }
    }
}
