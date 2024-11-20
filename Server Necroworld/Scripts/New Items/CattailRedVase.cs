using System;

namespace Server.Items
{
	public class CattailRedVase : Item
	{
		[Constructable]
		public CattailRedVase()
			: base(0xA0EB)
		{
			Movable = true;
			
			Name = "red vased cattail";

			Weight = 1.0;
		}

		public CattailRedVase(Serial serial)
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