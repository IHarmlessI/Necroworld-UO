using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a solen matriarch corpse")] // TODO: Corpse name?
    public class WhiteSolenMatriarch : BaseCreature, IBlackSolen
    {
        [Constructable]
        public WhiteSolenMatriarch()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "a white solen matriarch";
            this.Body = 807;
            this.BaseSoundID = 959;
            this.Hue = 2268;

            this.SetStr(726, 750);
            this.SetDex(141, 165);
            this.SetInt(396, 420);

            this.SetHits(5100, 6200);

            this.SetDamage(40, 55);

            this.SetDamageType(ResistanceType.Physical, 70);
            this.SetDamageType(ResistanceType.Poison, 30);

            this.SetResistance(ResistanceType.Physical, 30, 80);
            this.SetResistance(ResistanceType.Fire, 30, 85);
            this.SetResistance(ResistanceType.Cold, 25, 85);
            this.SetResistance(ResistanceType.Poison, 35, 80);
            this.SetResistance(ResistanceType.Energy, 25, 80);

            this.SetSkill(SkillName.MagicResist, 110.0);
            this.SetSkill(SkillName.Tactics, 110.0);
            this.SetSkill(SkillName.Wrestling, 110.0);

            this.Fame = 35000;
            this.Karma = -35000;

            this.VirtualArmor = 80;

            SolenHelper.PackPicnicBasket(this);

            this.PackItem(new ZoogiFungus((0.05 > Utility.RandomDouble()) ? 16 : 4));

            if (Utility.RandomDouble() < 0.75)
                this.PackItem(new BallOfSummoning());

            if (Utility.RandomDouble() < 0.75)
                this.PackItem(new BraceletOfBinding());
        }

        public WhiteSolenMatriarch(Serial serial)
            : base(serial)
        {
        }

        public override int GetAngerSound()
        {
            return 0x259;
        }

        public override int GetIdleSound()
        {
            return 0x259;
        }

        public override int GetAttackSound()
        {
            return 0x195;
        }

        public override int GetHurtSound()
        {
            return 0x250;
        }

        public override int GetDeathSound()
        {
            return 0x25B;
        }

        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.UltraRich);
            this.AddLoot(LootPack.UltraRich);
            this.AddLoot(LootPack.UltraRich);
            this.AddLoot(LootPack.UltraRich);
            this.AddLoot(LootPack.FilthyRich);
            this.AddLoot(LootPack.FilthyRich);
            this.AddLoot(LootPack.FilthyRich);
            this.AddLoot(LootPack.Rich);
            this.AddLoot(LootPack.Rich);
            this.AddLoot(LootPack.Rich);
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
