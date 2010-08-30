using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Sharp3D.Scene;
using Sharp3D.Scene.Cameras;
using Sharp3D.Scene.Lights;
using Sharp3D.Scene.Materials;
using Sharp3D.Scene.Models;
using Color = System.Windows.Media.Color;
using DirectionalLight = Sharp3D.Scene.Lights.DirectionalLight;
using PointLight = Sharp3D.Scene.Lights.PointLight;

namespace Sharp3D.UI.Widgets
{
    public static class SceneServices
    {
        public static void InitializeViewport(Viewport3D viewport3D, IScene scene)
        {
            if (viewport3D == null || scene == null) return;

            var objects = ConvertScene(scene);
            foreach (var visual3D in objects)
            {
                viewport3D.Children.Add(visual3D);
            }

            var camera = ConvertCamera(scene.Cameras.First());
            viewport3D.Camera = camera;
        }

        public static IEnumerable<Visual3D> ConvertScene(IScene scene)
        {
            var visuals = new List<Visual3D>();

            foreach (var model in scene.Models)
            {
                var modelVisual3D = new ModelVisual3D();
                modelVisual3D.Content = ConvertModel(model);

                visuals.Add(modelVisual3D);
            }

            foreach (var light in scene.Lights)
            {
                var modelVisual3D = new ModelVisual3D();
                modelVisual3D.Content = ConvertLight(light);

                visuals.Add(modelVisual3D);
            }

            return visuals;
        }

        public static Camera ConvertCamera(ICamera camera)
        {
            return new PerspectiveCamera(
                new Point3D(camera.Position.X, camera.Position.Y, camera.Position.Z),
                new Vector3D(camera.LookAt.X, camera.LookAt.Y, camera.LookAt.Z),
                new Vector3D(0, -1, 0), camera.FieldOfView);
        }

        public static Light ConvertLight(ILight light)
        {
            if (light is PointLight)
            {
                var pointLight = (PointLight) light;
                return new System.Windows.Media.Media3D.PointLight(
                    ConvertColor(pointLight.Color),
                    new Point3D(pointLight.Position.X,
                                pointLight.Position.Y,
                                pointLight.Position.Z));
            }
            
            if (light is DirectionalLight)
            {
                var directionalLight = (DirectionalLight)light;
                return new System.Windows.Media.Media3D.DirectionalLight(
                    ConvertColor(directionalLight.Color),
                    new Vector3D(directionalLight.Direction.X,
                                 directionalLight.Direction.Y,
                                 directionalLight.Direction.Z));
            }

            return null;
        }

        public static GeometryModel3D ConvertModel(IModel model)
        {
            var mesh = model.Tesselate();
            var meshGeometry3D = ConvertMesh(mesh);
            var materialGroup = ConvertMaterial(model.Material);
            var geometryModel3D = new GeometryModel3D(meshGeometry3D, materialGroup);

            return geometryModel3D;
        }

        public static MaterialGroup ConvertMaterial(IMaterial material)
        {
            var materialGroup = new MaterialGroup();
            var diffuseColor = ConvertColor(material.Diffuse);
            var diffuseMaterial = new DiffuseMaterial(new SolidColorBrush(diffuseColor));
            materialGroup.Children.Add(diffuseMaterial);

            return materialGroup;
        }

        public static Color ConvertColor(Scene.Primitives.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static MeshGeometry3D ConvertMesh(Mesh mesh)
        {
            var meshGeometry3D = new MeshGeometry3D();

            foreach (var position in mesh.Positions)
            {
                meshGeometry3D.Positions.Add(new Point3D(position.X, position.Y, position.Z));
            }

            foreach (var triangleIndex in mesh.TriangleIndices)
            {
                meshGeometry3D.TriangleIndices.Add(triangleIndex);
            }

            foreach (var normal in mesh.Normals)
            {
                meshGeometry3D.Normals.Add(new Vector3D(normal.X, normal.Y, normal.Z));
            }

            foreach (var point2 in mesh.UV)
            {
                meshGeometry3D.TextureCoordinates.Add(new Point(point2.X, point2.Y));
            }

            return meshGeometry3D;
        }
    }
}