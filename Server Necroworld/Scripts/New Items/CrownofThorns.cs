using System;

namespace Server.Items
{
	public class CrownofThorns : Item
	{
		[Constructable]
		public CrownofThorns(int hue)
			: base(0x9B11)
		{
			Movable = true;
			
			Name = "crown of thorns";
			Hue = hue;

			Weight = 1.0;
		}

		public CrownofThorns(Serial serial)
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