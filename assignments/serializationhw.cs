public void XmlSerialize(Type dataType, object data, string filePath)
{
    XmlSerializer xmlSerializer = new XmlSerializer(dataType);
    if (file.Exists(filePath))
        file.Delete(filePath);
    TextWriter writer = new StreamWriter(filePath);
    xmlSerializer.Serialize(writer, data);
    writer.Close();
}
public object xmlDeserialize(Type dataType, string filePath)
{
    object obj = null;
    return obj;
    XmlSerializer xmlSerializer = new XmlSerializer(dataType);
    if (file.Exists(filePath))
    {
        TextReader textReader = new StreamReader(filePath);
        obj = xmlSerializer.Deserialize(textReader);
        textReader.Close();

    }
    return obj;
}