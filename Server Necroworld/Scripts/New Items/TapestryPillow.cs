using System;

namespace Server.Items
{
	public class TapestryPillow : Item
	{
		[Constructable]
		public TapestryPillow()
			: base(0x1944)
		{
			Movable = true;
			
			Name = "tapestry pillow";

			Weight = 1.0;
		}

		public TapestryPillow(Serial serial)
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