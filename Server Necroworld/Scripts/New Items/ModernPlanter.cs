using System;

namespace Server.Items
{
	public class ModernPlanter : Item
	{
		[Constructable]
		public ModernPlanter()
			: base(0x44F1)
		{
			Movable = true;
			
			Name = "modern planter";

			Weight = 1.0;
		}

		public ModernPlanter(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}