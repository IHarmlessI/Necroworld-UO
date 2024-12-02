using System;

namespace Server.Mobiles
{
    [CorpseName("an acid rat corpse")]
    public class AcidRat : BaseCreature
    {
        [Constructable]
        public AcidRat()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            this.Name = "an acid rat";
            this.Body = 238;
            this.BaseSoundID = 0xCC;
            Hue = 2176;

            this.SetStr(90);
            this.SetDex(75);
            this.SetInt(50);

            this.SetHits(60);
            this.SetMana(0);

            this.SetDamage(21, 26);

            this.SetDamageType(ResistanceType.Poison, 100);

            this.SetResistance(ResistanceType.Physical, 5, 10);
            this.SetResistance(ResistanceType.Poison, 5, 10);

            this.SetSkill(SkillName.MagicResist, 4.0);
            this.SetSkill(SkillName.Tactics, 4.0);
            this.SetSkill(SkillName.Wrestling, 4.0);

            this.Fame = 150;
            this.Karma = -150;

            this.VirtualArmor = 6;

            this.Tamable = true;
            this.ControlSlots = 1;
            this.MinTameSkill = 21.9;
        }

        public AcidRat (Serial serial)
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
        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.Meat | FoodType.Fish | FoodType.Eggs | FoodType.GrainsAndHay;
            }
        }
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Rich);
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