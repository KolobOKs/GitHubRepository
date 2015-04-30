package HeadOfDepartmentsWebService;

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
 * Created by Shabalina Nika on 01.05.2015.
 */
public class Model {
    private static  String _pathToXmlDocument="C:\\headOfDepartmentsList.xml";

    public static List<String> getHeadOfDepartmentsNames(){
        File xmlDocuments = new File(_pathToXmlDocument);
        List<String> resultList = new ArrayList<String>();

        DocumentBuilderFactory dbFactory= DocumentBuilderFactory.newInstance();
        try {
            DocumentBuilder dBuilder=dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(xmlDocuments);
            doc.getDocumentElement().normalize();

            NodeList headOfDepartment = doc.getElementsByTagName("head");
            for (int i=0; i< headOfDepartment.getLength(); i++){
                Node inst = headOfDepartment.item(i);
                Element element = (Element) inst;
                resultList.add(getValue("name", element));
            }
            return resultList;

        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    public static String getHeadOfDepartmentEmail(String headName){
        File xmlDocument = new File(_pathToXmlDocument);
        DocumentBuilderFactory dbFactory= DocumentBuilderFactory.newInstance();
        try {
            DocumentBuilder dBuilder=dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(xmlDocument);
            doc.getDocumentElement().normalize();

            NodeList headOfDepartment = doc.getElementsByTagName("head");

            for (int i=0; i< headOfDepartment.getLength(); i++){
                Node currentHead = headOfDepartment.item(i);
                Element element = (Element) currentHead;

                if(headName.equals(getValue("name", element))){
                    return getValue("email",element);
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
