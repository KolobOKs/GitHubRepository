package example;

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
 * Created by Masha on 03.05.2015.
 */
public class Database {
    private static  String _pathToXmlDocument="C:\\teachers.xml";

    public static List<String> getTeachers(){
        File teachers = new File(_pathToXmlDocument);
        List<String> resultList = new ArrayList<String>();

        DocumentBuilderFactory dbFactory= DocumentBuilderFactory.newInstance();
        try {
            DocumentBuilder dBuilder=dbFactory.newDocumentBuilder();
            Document document = dBuilder.parse(teachers);
            document.getDocumentElement().normalize();

            NodeList institute = document.getElementsByTagName("tutor");
            for (int i=0; i< institute.getLength(); i++){
                Node tutor = institute.item(i);
                Element element = (Element) tutor;
                resultList.add(getValue("name", element));
            }
            return resultList;

        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    public static String getPosition(String tutorName){
        File teachers = new File(_pathToXmlDocument);
        DocumentBuilderFactory dbFactory= DocumentBuilderFactory.newInstance();
        try {
            DocumentBuilder dBuilder=dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(teachers);
            doc.getDocumentElement().normalize();

            NodeList tutor = doc.getElementsByTagName("tutor");

            for (int i=0; i< tutor.getLength(); i++){
                Node t = tutor.item(i);
                Element element = (Element) t;

                if(tutorName.equals(getValue("name", element))){
                    return getValue("position",element);
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
