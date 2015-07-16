using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BAnimator
{
    public class Character
    {
        protected const string _file_id = "BAnimator by Worlaff Character File";
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Version { get; protected set; }

        public Bone RootBone { get; set; }
        public BoneGraphicsManager GraphicsManager { get; protected set; }
        public CharacterStateManager StateManager { get; protected set; }

        public Character()
        {
            Version = 1;
            Name = "Unnamed";
            Author = "";
            Description = "";
            GraphicsManager = new BoneGraphicsManager(this);
            StateManager = new CharacterStateManager();

        }

        public void Save(string filename)
        {
            BinaryWriter writer = new BinaryWriter(File.Create(filename));
            writer.Write(_file_id);
            writer.Write(Version);
            writer.Write(Name);
            writer.Write(Author);
            writer.Write(Description);
            WriteBone(RootBone, writer);
            
        }

        protected void WriteBone(Bone b, BinaryWriter writer)
        {
            if (b.Name == null)
                b.Name = "";
            writer.Write(b.Name);
            writer.Write(b.ID);
            writer.Write(b.IsRoot);
            if (!b.IsRoot)
            {
                writer.Write(b.Angle);
                writer.Write(b.Length);
                writer.Write(b.Shift.X);
                writer.Write(b.Shift.Y);
            }
            writer.Write(b.Children.Count);
            for (int i = 0; i < b.Children.Count; i++)
            {
                WriteBone(b.Children[i], writer);
            }
        }

        public static Character Load(string filename)
        {

            
            BinaryReader reader = new BinaryReader(File.OpenRead(filename));

            Character ch = new Character();

            string file_id = reader.ReadString();
            if (file_id != _file_id)
            {
                throw new Exception("Wrong file id");
            }
            int version = reader.ReadInt32();
            if (version == 1)
                LoadV1(ch, reader);

            return ch;
        }

        private static void ReadBone(Bone parent, BinaryReader reader)
        {
            string name = reader.ReadString() ;
            uint id = reader.ReadUInt32();
            bool isRoot = reader.ReadBoolean();
            if (isRoot)
            {
                throw new Exception("Неожиданная ошибка при чтении файла: не корневая кость помечена, как корневая");
            }
            double angle = reader.ReadDouble();
            double length = reader.ReadDouble();
            float sx = reader.ReadSingle();
            float sy = reader.ReadSingle();
            Bone bone = new Bone(parent, angle, length, new System.Drawing.PointF(sx, sy), name, id);
            int count = reader.ReadInt32();
           
            for (int i = 0; i < count; i++)
            {
                ReadBone(bone, reader);
            }
        }

        #region Version 1 Loader
        private static void LoadV1(Character ch, BinaryReader reader)
        {
            ch.Name = reader.ReadString();
            ch.Author = reader.ReadString();
            ch.Description = reader.ReadString();
            //root bone read
            Bone root = new Bone();
            root.Name = reader.ReadString();
            uint id = reader.ReadUInt32();
            bool isroot = reader.ReadBoolean();
            if (!isroot)
            {
                throw new Exception("Неожиданная ошибка при чтении файла: первая кость не помечена, как корневая");
            }
            ch.RootBone = root;
            int children = reader.ReadInt32();
            for (int i = 0; i < children; i++)
            {
                ReadBone(root, reader);
            }
        }
        #endregion
    }
}
