namespace Mediag.Medical
{
    interface IMedicalData
    {
        IllnessTypes TargettedIllness();

        string[] Values();

        string[] Labels();
    }
}
