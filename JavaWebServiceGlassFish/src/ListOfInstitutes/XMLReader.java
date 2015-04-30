package ListOfInstitutes;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import java.io.File;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Kirill Maloyaroslavtsev on 30.04.2015.
 */
public class XMLReader {

    private static  String _pathToXmlDocument="C:\\listsOfInstitutes.xml";

    public static List<String> getInstitutesNamesList(){
        File institutes = new File(_pathToXmlDocument);
        List<String> resultList = new ArrayList<String>();

        DocumentBuilderFactory dbFactory= DocumentBuilderFactory.newInstance();
        try {
            DocumentBuilder dBuilder=dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(institutes);
            doc.getDocumentElement().normalize();

            NodeList institute = doc.getElementsByTagName("institute");
            for (int i=0; i< institute.getLength(); i++){
                Node inst = institute.item(i);
                Element element = (Element) inst;
                resultList.add(getValue("name", element));
            }
            return resultList;

        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    public static String getDescriptionOfInstitute(String instituteName){
        File institutes = new File(_pathToXmlDocument);
        DocumentBuilderFactory dbFactory= DocumentBuilderFactory.newInstance();
        try {
            DocumentBuilder dBuilder=dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(institutes);
            doc.getDocumentElement().normalize();

            NodeList institute = doc.getElementsByTagName("institute");

            for (int i=0; i< institute.getLength(); i++){
                Node inst = institute.item(i);
                Element element = (Element) inst;

               if(instituteName.equals(getValue("name", element))){
                    return getValue("description",element);
               }
            }
            return "";

        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    private static String getValue(String tag, Element element){
        NodeList nodes = element.getElementsByTagName(tag).item(0).getChildNodes();
        Node node = nodes.item(0);
        return node.getNodeValue();
    }
}
