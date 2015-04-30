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
 * Created by NPoguca on 03.05.2015.
 */
public class XmlParser {
    private static  String _pathToXmlDocument="C:\\abbr.xml";

    public static List<String> getAbbrList(){
        File abbrs = new File(_pathToXmlDocument);
        List<String> resultList = new ArrayList<String>();

        DocumentBuilderFactory dbFactory= DocumentBuilderFactory.newInstance();
        try {
            DocumentBuilder dBuilder=dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(abbrs);
            doc.getDocumentElement().normalize();

            NodeList n = doc.getElementsByTagName("abr");
            for (int i=0; i< n.getLength(); i++){
                Node current = n.item(i);
                Element element = (Element) current;
                resultList.add(getValue("name", element));
            }
            return resultList;

        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    public static String getFullName(String abrName){
        File institutes = new File(_pathToXmlDocument);
        DocumentBuilderFactory dbFactory= DocumentBuilderFactory.newInstance();
        try {
            DocumentBuilder dBuilder=dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(institutes);
            doc.getDocumentElement().normalize();

            NodeList abr = doc.getElementsByTagName("abr");

            for (int i=0; i< abr.getLength(); i++){
                Node current = abr.item(i);
                Element element = (Element) current;

                if(abrName.equals(getValue("name", element))){
                    return getValue("fullname",element);
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
