using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a solen worker corpse")]
    public class WhiteSolenWorker : BaseCreature, IBlackSolen
    {
        [Constructable]
        public WhiteSolenWorker()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "a white solen worker";
            this.Body = 805;
            this.BaseSoundID = 959;
            this.Hue = 2268;

            this.SetStr(196, 320);
            this.SetDex(81, 105);
            this.SetInt(136, 160);

            this.SetHits(140, 172);

            this.SetDamage(11, 17);

            this.SetDamageType(ResistanceType.Poison, 100);

            this.SetResistance(ResistanceType.Physical, 25, 50);
            this.SetResistance(ResistanceType.Fire, 20, 50);
            this.SetResistance(ResistanceType.Cold, 10, 30);
            this.SetResistance(ResistanceType.Poison, 10, 80);
            this.SetResistance(ResistanceType.Energy, 20, 50);

            this.SetSkill(SkillName.MagicResist, 90.0);
            this.SetSkill(SkillName.Poisoning, 90.0);
            this.SetSkill(SkillName.Tactics, 75.0);
            this.SetSkill(SkillName.Wrestling, 70.0);

            this.Fame = 3500;
            this.Karma = -3500;

            this.VirtualArmor = 48;

            this.PackGold(Utility.Random(250, 400));

            SolenHelper.PackPicnicBasket(this);
            AddLoot(LootPack.Average);
            this.PackItem(new ZoogiFungus());
        }

        public WhiteSolenWorker(Serial serial)
            : base(serial)
        {
        }
        public override Poison HitPoison
        {
            get
            {
                return Poison.Lesser;
            }
        }

        public override int GetAngerSound()
        {
            return 0x269;
        }

        public override int GetIdleSound()
        {
            return 0x269;
        }

        public override int GetAttackSound()
        {
            return 0x186;
        }

        public override int GetHurtSound()
        {
            return 0x1BE;
        }

        public override int GetDeathSound()
        {
            return 0x8E;
        }

        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Gems, Utility.RandomMinMax(1, 4));
        }

        public override bool IsEnemy(Mobile m)
        {
            if (SolenHelper.CheckBlackFriendship(m))
                return base.IsEnemy(m);
            else
                return base.IsEnemy(m);
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            SolenHelper.OnBlackDamage(from);

            base.OnDamage(amount, from, willKill);
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
