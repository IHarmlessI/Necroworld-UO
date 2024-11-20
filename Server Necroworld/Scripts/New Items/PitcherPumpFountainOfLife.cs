using System;

namespace Server.Items
{
    [FlipableAttribute(0xA633, 0xA636)]
    public class PitcherPumpFountainOfLife : BaseAddonContainer
    {
        private int m_Charges;
        private Timer m_Timer;
        [Constructable]
        public PitcherPumpFountainOfLife()
            : this(10)
        {
        }

        [Constructable]
        public PitcherPumpFountainOfLife(int charges)
            : base(0xA633)
        {
            m_Charges = charges;

            m_Timer = Timer.DelayCall(RechargeTime, RechargeTime, new TimerCallback(Recharge));
        }

        public PitcherPumpFountainOfLife(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonContainerDeed Deed
        {
            get
            {
                return new PitcherPumpFountainOfLifeDeed(m_Charges);
            }
        }
        public virtual TimeSpan RechargeTime
        {
            get
            {
                return TimeSpan.FromDays(1);
            }
        }
        public override int LabelNumber
        {
            get
            {
                return 1075197;
            }
        }// Fountain of Life
        public override int DefaultGumpID
        {
            get
            {
                return 0x484;
            }
        }
        public override int DefaultDropSound
        {
            get
            {
                return 66;
            }
        }
        public override int DefaultMaxItems
        {
            get
            {
                return 125;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Charges
        {
            get
            {
                return m_Charges;
            }
            set
            {
                m_Charges = Math.Min(value, 10);
                InvalidateProperties();
            }
        }
        public override bool OnDragLift(Mobile from)
        {
            return false;
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            if (dropped is Bandage)
            {
                bool allow = base.OnDragDrop(from, dropped);

                if (allow)
                    Enhance(from);

                return allow;
            }
            else
            {
                from.SendLocalizedMessage(1075209); // Only bandages may be dropped into the fountain.
                return false;
            }
        }

        public override bool OnDragDropInto(Mobile from, Item item, Point3D p)
        {
            if (item is Bandage)
            {
                bool allow = base.OnDragDropInto(from, item, p);

                if (allow)
                    Enhance(from);

                return allow;
            }
            else
            {
                from.SendLocalizedMessage(1075209); // Only bandages may be dropped into the fountain.
                return false;
            }
        }

        public override void AddNameProperties(ObjectPropertyList list)
        {
            base.AddNameProperties(list);

            list.Add(1075217, m_Charges.ToString()); // ~1_val~ charges remaining
        }

        public override void OnDelete()
        {
            if (m_Timer != null)
                m_Timer.Stop();

            base.OnDelete();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); //version

            writer.Write(m_Charges);
            writer.Write((DateTime)m_Timer.Next);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();

            m_Charges = reader.ReadInt();

            DateTime next = reader.ReadDateTime();

            if (next < DateTime.UtcNow)
                m_Timer = Timer.DelayCall(TimeSpan.Zero, RechargeTime, new TimerCallback(Recharge));
            else
                m_Timer = Timer.DelayCall(next - DateTime.UtcNow, RechargeTime, new TimerCallback(Recharge));
        }

        public void Recharge()
        {
            m_Charges = 10;

            Enhance(null);
        }

        public void Enhance(Mobile from)
        {
			EnhancedBandage existing = null;

			foreach(Item item in Items)
			{
				if(item is EnhancedBandage)
				{
					existing = item as EnhancedBandage;
					break;
				}
			}

            for (int i = Items.Count - 1; i >= 0 && m_Charges > 0; --i)
            {
                if (Items[i] is EnhancedBandage)
                    continue;

                Bandage bandage = Items[i] as Bandage;

                if (bandage != null)
                {
                    Item enhanced;

                    if (bandage.Amount > m_Charges)
                    {
                        bandage.Amount -= m_Charges;
                        enhanced = new EnhancedBandage(m_Charges);
                        m_Charges = 0;
                    }
                    else
                    {
                        enhanced = new EnhancedBandage(bandage.Amount);
                        m_Charges -= bandage.Amount;
                        bandage.Delete();
                    }

					// try stacking first
					if (from == null || !TryDropItem(from, enhanced, false))
					{
						if (existing != null)
							existing.StackWith(from, enhanced);
						else
							DropItem(enhanced);
					}
                }
            }

            InvalidateProperties();
        }
    }

    public class PitcherPumpFountainOfLifeDeed : BaseAddonContainerDeed
    {
        private int m_Charges;
        [Constructable]
        public PitcherPumpFountainOfLifeDeed()
            : this(10)
        {
        }

        [Constructable]
        public PitcherPumpFountainOfLifeDeed(int charges)
            : base()
        {
            LootType = LootType.Blessed;
            m_Charges = charges;
        }

        public PitcherPumpFountainOfLifeDeed(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1075197;
            }
        }// Fountain of Life
        public override BaseAddonContainer Addon
        {
            get
            {
                return new PitcherPumpFountainOfLife(m_Charges);
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Charges
        {
            get
            {
                return m_Charges;
            }
            set
            {
                m_Charges = Math.Min(value, 10);
                InvalidateProperties();
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); //version

            writer.Write(m_Charges);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();

            m_Charges = reader.ReadInt();
        }
    }
}
