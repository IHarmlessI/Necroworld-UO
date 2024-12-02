using System;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a giant star beetle corpse")]
    public class StarBeetle : BaseMount
    {
        public virtual double BoostedSpeed
        {
            get
            {
                return 0.1;
            }
        }

        [Constructable]
        public StarBeetle()
            : this("a giant star beetle")
        {
        }

        public override bool SubdueBeforeTame
        {
            get
            {
                return true;
            }
        }// Must be beaten into submission
        public override bool ReduceSpeedWithDamage
        {
            get
            {
                return false;
            }
        }

        [Constructable]
        public StarBeetle(string name)
            : base(name, 0x317, 0x3EBC, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.25, 0.5)
        {
            SetStr(800);
            SetDex(100);
            SetInt(600);
            Hue = 1090;

            SetHits(800);

            SetDamage(37, 50);

            SetDamageType(ResistanceType.Energy, 100);

            SetResistance(ResistanceType.Physical, 60, 70);
            SetResistance(ResistanceType.Fire, 60, 70);
            SetResistance(ResistanceType.Cold, 60, 70);
            SetResistance(ResistanceType.Poison, 60, 70);
            SetResistance(ResistanceType.Energy, 60, 70);

            SetSkill(SkillName.MagicResist, 110.0);
            SetSkill(SkillName.Tactics, 130.0);
            SetSkill(SkillName.Wrestling, 130.0);

            Fame = 10000;
            Karma = -10000;

            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 79.1;

            Container pack = Backpack;

            if (pack != null)
                pack.Delete();

            pack = new StrongBackpack();
            pack.Movable = false;

            AddItem(pack);
        }

        public override int GetAngerSound()
        {
            return 0x21D;
        }

        public override int GetIdleSound()
        {
            return 0x21D;
        }

        public override int GetAttackSound()
        {
            return 0x162;
        }

        public override int GetHurtSound()
        {
            return 0x163;
        }

        public override int GetDeathSound()
        {
            return 0x21D;
        }

        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.Meat;
            }
        }

        public override bool CanAutoStable { get { return (Backpack == null || Backpack.Items.Count == 0) && base.CanAutoStable; } }

        public StarBeetle(Serial serial)
            : base(serial)
        {
        }

        public override void OnHarmfulSpell(Mobile from)
        {
            if (!Controlled && ControlMaster == null)
                CurrentSpeed = BoostedSpeed;
        }

        public override void OnCombatantChange()
        {
            if (Combatant == null && !Controlled && ControlMaster == null)
                CurrentSpeed = PassiveSpeed;
        }

        #region Pack Animal Methods
        public override bool OnBeforeDeath()
        {
            if (!base.OnBeforeDeath())
                return false;

            PackAnimal.CombineBackpacks(this);

            return true;
        }

        public override DeathMoveResult GetInventoryMoveResultFor(Item item)
        {
            return DeathMoveResult.MoveToCorpse;
        }

        public override bool IsSnoop(Mobile from)
        {
            if (PackAnimal.CheckAccess(this, from))
                return false;

            return base.IsSnoop(from);
        }

        public override bool OnDragDrop(Mobile from, Item item)
        {
            if (CheckFeed(from, item))
                return true;

            if (PackAnimal.CheckAccess(this, from))
            {
                AddToBackpack(item);
                return true;
            }

            return base.OnDragDrop(from, item);
        }

        public override bool CheckNonlocalDrop(Mobile from, Item item, Item target)
        {
            return PackAnimal.CheckAccess(this, from);
        }

        public override bool CheckNonlocalLift(Mobile from, Item item)
        {
            return PackAnimal.CheckAccess(this, from);
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            PackAnimal.GetContextMenuEntries(this, from, list);
        }

        #endregion

        public override void OnAfterTame(Mobile tamer)
        {
            base.OnAfterTame(tamer);

            if (Owners.Count == 0 && PetTrainingHelper.Enabled)
            {
                SetInt(500);
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version < 1 && PetTrainingHelper.Enabled && ControlSlots <= 3)
            {
                var profile = PetTrainingHelper.GetAbilityProfile(this);

                if (profile == null || !profile.HasCustomized())
                {
                    MinTameSkill = 98.7;
                    ControlSlotsMin = 1;
                    ControlSlots = 1;
                }

                if ((ControlMaster != null || IsStabled) && Int < 500)
                {
                    SetInt(500);
                }
            }
        }
    }
}