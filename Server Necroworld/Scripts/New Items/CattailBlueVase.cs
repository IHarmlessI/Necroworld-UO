using System;

namespace Server.Items
{
	public class CattailBlueVase : Item
	{
		[Constructable]
		public CattailBlueVase()
			: base(0xA0EC)
		{
			Movable = true;
			
			Name = "blue vased cattail";

			Weight = 1.0;
		}

		public CattailBlueVase(Serial serial)
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