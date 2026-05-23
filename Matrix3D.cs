namespace project_1
{
    internal class Matrix3D
    {
        public float[,] M = new float[3, 3];

        public static Matrix3D Rotation(float rotX, float rotY)
        {
            float rx = rotX * (float)Math.PI / 180f;
            float ry = rotY * (float)Math.PI / 180f;

            float sinX = (float)Math.Sin(rx);
            float cosX = (float)Math.Cos(rx);
            float sinY = (float)Math.Sin(ry);
            float cosY = (float)Math.Cos(ry);

            Matrix3D m = new Matrix3D();

            // دوران حول محور Y
            m.M[0, 0] = cosY;
            m.M[0, 1] = 0;
            m.M[0, 2] = sinY;

            // دوران حول محور X
            m.M[1, 0] = sinX * sinY;
            m.M[1, 1] = cosX;
            m.M[1, 2] = -sinX * cosY;

            m.M[2, 0] = -cosX * sinY;
            m.M[2, 1] = sinX;
            m.M[2, 2] = cosX * cosY;

            return m;
        }

        public Vector3D Transform(Vector3D v)
        {
            return new Vector3D(
                v.X * M[0, 0] + v.Y * M[0, 1] + v.Z * M[0, 2],
                v.X * M[1, 0] + v.Y * M[1, 1] + v.Z * M[1, 2],
                v.X * M[2, 0] + v.Y * M[2, 1] + v.Z * M[2, 2]
            );
        }
    }
}
