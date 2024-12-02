using System;
using System.Collections;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("a solen queen corpse")]
    public class WhiteSolenQueen : BaseCreature, IBlackSolen
    {
        private bool m_BurstSac;
        private static bool m_Laid;

        [Constructable]
        public WhiteSolenQueen()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "a white solen queen";
            this.Body = 807;
            this.BaseSoundID = 959;
            this.Hue = 2268;

            this.SetStr(496, 520);
            this.SetDex(121, 145);
            this.SetInt(276, 300);

            this.SetHits(451, 462);

            this.SetDamage(20, 25);

            this.SetDamageType(ResistanceType.Physical, 40);
            this.SetDamageType(ResistanceType.Poison, 60);

            this.SetResistance(ResistanceType.Physical, 30, 60);
            this.SetResistance(ResistanceType.Fire, 30, 65);
            this.SetResistance(ResistanceType.Cold, 25, 65);
            this.SetResistance(ResistanceType.Poison, 35, 60);
            this.SetResistance(ResistanceType.Energy, 25, 60);

            this.SetSkill(SkillName.MagicResist, 90.0);
            this.SetSkill(SkillName.Tactics, 110.0);
            this.SetSkill(SkillName.Wrestling, 110.0);

            this.Fame = 8500;
            this.Karma = -8500;

            this.VirtualArmor = 65;

            SolenHelper.PackPicnicBasket(this);

            this.PackItem(new ZoogiFungus((Utility.RandomDouble() > 0.05) ? 5 : 25));

            if (Utility.RandomDouble() < 0.20)
                this.PackItem(new BallOfSummoning());
        }

        public override Poison HitPoison
        {
            get
            {
                return Poison.Lesser;
            }
        }

        public WhiteSolenQueen(Serial serial)
            : base(serial)
        {
        }

        public bool BurstSac
        {
            get
            {
                return this.m_BurstSac;
            }
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
            this.AddLoot(LootPack.Rich);
            this.AddLoot(LootPack.UltraRich);
            this.AddLoot(LootPack.FilthyRich);
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            if (attacker.Weapon is BaseRanged)
                BeginAcidBreath();

            else if (this.Map != null && attacker != this && m_Laid == false && 0.20 > Utility.RandomDouble())
            {
                BSQEggSacI sac = new BSQEggSacI();

                sac.MoveToWorld(this.Location, this.Map);
                PlaySound(0x582);
                Say(1114445); // * * The solen queen summons her workers to her aid! * *
                m_Laid = true;
                EggSacTimerI e = new EggSacTimerI();
                e.Start();
            }

            base.OnGotMeleeAttack(attacker);
        }

        public override void OnDamagedBySpell(Mobile attacker)
        {
            base.OnDamagedBySpell(attacker);

            if (0.80 >= Utility.RandomDouble())
                BeginAcidBreath();
        }

        #region Acid Breath
        private DateTime m_NextAcidBreath;

        public void BeginAcidBreath()
        {
            PlayerMobile m = Combatant as PlayerMobile;

            if (m == null || m.Deleted || !m.Alive || !Alive || m_NextAcidBreath > DateTime.Now || !CanBeHarmful(m))
                return;

            PlaySound(0x118);
            MovingEffect(m, 0x36D4, 1, 0, false, false, 0x3F, 0);

            TimeSpan delay = TimeSpan.FromSeconds(GetDistanceToSqrt(m) / 5.0);
            Timer.DelayCall<Mobile>(delay, new TimerStateCallback<Mobile>(EndAcidBreath), m);

            m_NextAcidBreath = DateTime.Now + TimeSpan.FromSeconds(5);
        }

        public void EndAcidBreath(Mobile m)
        {
            if (m == null || m.Deleted || !m.Alive || !Alive)
                return;

            if (0.2 >= Utility.RandomDouble())
                m.ApplyPoison(this, Poison.Greater);

            AOS.Damage(m, Utility.RandomMinMax(100, 120), 0, 0, 0, 100, 0);
        }
        #endregion

        private class EggSacTimerI : Timer
        {
            public EggSacTimerI()
                : base(TimeSpan.FromSeconds(10))
            {
                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                m_Laid = false;

            }
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

            if (!willKill)
            {
                if (!this.BurstSac)
                {
                    if (this.Hits < 50)
                    {
                        this.PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* The solen's acid sac is burst open! *");
                        this.m_BurstSac = true;
                    }
                }
                else if (from != null && from != this && this.InRange(from, 1))
                {
                    this.SpillAcid(from, 1);
                }
            }

            base.OnDamage(amount, from, willKill);
        }

        public override bool OnBeforeDeath()
        {
            this.SpillAcid(4);

            return base.OnBeforeDeath();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1);
            writer.Write(this.m_BurstSac);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
			
            switch( version )
            {
                case 1:
                    {
                        this.m_BurstSac = reader.ReadBool();
                        break;
                    }
            }
        }
    }

    public class BSQEggSacI : Item, ICarvable
    {
        private SpawnTimer m_Timer;

        public override string DefaultName
        {
            get { return "egg sac"; }
        }

        [Constructable]
        public BSQEggSacI()
            : base(4316)
        {
            Movable = false;
            Hue = 350;

            m_Timer = new SpawnTimer(this);
            m_Timer.Start();
        }

        public bool Carve(Mobile from, Item item)
        {
            Effects.PlaySound(GetWorldLocation(), Map, 0x027);
            Effects.SendLocationEffect(GetWorldLocation(), Map, 0x3728, 10, 10, 0, 0);

            from.SendMessage("You destroy the egg sac.");
            Delete();
            m_Timer.Stop();

            return true;
        }

        public BSQEggSacI(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Timer = new SpawnTimer(this);
            m_Timer.Start();
        }

        private class SpawnTimer : Timer
        {
            private Item m_Item;

            public SpawnTimer(Item item)
                : base(TimeSpan.FromSeconds(Utility.RandomMinMax(5, 10)))
            {
                Priority = TimerPriority.FiftyMS;

                m_Item = item;
            }

            protected override void OnTick()
            {
                if (m_Item.Deleted)
                    return;

                Mobile spawn;

                switch (Utility.Random(2))
                {
                    case 0:
                        spawn = new WhiteSolenWarrior();
                        spawn.MoveToWorld(m_Item.Location, m_Item.Map);
                        m_Item.Delete();
                        break;
                    case 1:
                        spawn = new WhiteSolenWorker();
                        spawn.MoveToWorld(m_Item.Location, m_Item.Map);
                        m_Item.Delete();
                        break;
                }
            }
        }
    }
}
