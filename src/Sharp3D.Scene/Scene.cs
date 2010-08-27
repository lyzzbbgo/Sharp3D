using System;
using System.Collections.Generic;
using Sharp3D.Scene.Cameras;
using Sharp3D.Scene.Lights;
using Sharp3D.Scene.Materials;
using Sharp3D.Scene.Models;
using Sharp3D.Scene.Primitives;

namespace Sharp3D.Scene
{
    public class Scene : IScene
    {
        public Scene()
        {
            Cameras = new List<ICamera>();
            Lights = new List<ILight>();
            Materials = new List<IMaterial>();
            Models = new List<IModel>();
        }

        public ICollection<ICamera> Cameras { get; private  set; }

        public ICollection<ILight> Lights { get; private set; }

        public ICollection<IMaterial> Materials { get; private set; }

        public ICollection<IModel> Models { get; private set; }

        public Color Background { get; set; }
    }
}