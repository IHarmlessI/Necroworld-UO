using System;

namespace Server.Items
{
	public class AmyrillisPlant : Item
	{
		[Constructable]
		public AmyrillisPlant(int hue)
			: base(0x9D3E)
		{
			Movable = true;
			
			Name = "amyrillis plant";
			Hue = hue;

			Weight = 1.0;
		}

		public AmyrillisPlant(Serial serial)
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