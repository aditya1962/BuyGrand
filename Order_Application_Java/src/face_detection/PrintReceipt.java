/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package face_detection;

import com.itextpdf.text.BadElementException;
import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Element;
import com.itextpdf.text.Image;
import com.itextpdf.text.PageSize;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.Phrase;
import com.itextpdf.text.Rectangle;
import com.itextpdf.text.pdf.PdfPCell;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;
import java.awt.Desktop;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.logging.Level;
import java.util.logging.Logger;
import order_application_java.PopulateCart;

/**
 *
 * @author Aditya
 */
public class PrintReceipt {
    private double totalPrice;
    
    public void setTotalPrice(double price)
    {
        totalPrice = price;
    }
    public double getTotalPrice()
    {
        return totalPrice;
    }
    public void receipt(String username) throws FileNotFoundException, DocumentException, BadElementException, IOException, SQLException {
        File image = new File("submitted_image.png");
        while(!image.isFile())
        {
            try {
                Thread.sleep(10000);
            } catch (InterruptedException ex) {
                Logger.getLogger(FaceDetect.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        final String DEST = "invoice_"+username+".pdf";
        File file = new File(DEST);
        file.getAbsoluteFile().getParentFile();

        Document doc = new Document(PageSize.A4, 25f, 18f, 18f, 5f);
        PdfWriter.getInstance(doc,new FileOutputStream(file));
        doc.open();
        addLogo(doc);
        letterHead(doc);        
        beneficiary(doc,username);
        table(doc, file,username);
        signature(doc);
        doc.close();
        if(Desktop.isDesktopSupported())
        {
            try
            {
                Desktop.getDesktop().open(file);
            }
            catch(IOException e)
            {
                e.printStackTrace();
            }
        }
    }
   
    public void beneficiary(Document doc, String username) throws DocumentException
    {
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss");
        LocalDateTime now = LocalDateTime.now();
        Paragraph text = new Paragraph(dtf.format(now)+"\n\nDear "+username+",\n"+"Here is the receipt for items you ordered:\n\n");
        doc.add(text);
    }
    public void letterHead(Document doc) throws DocumentException
    {
        Paragraph headerText = new Paragraph("BuyGrand \n 12/A, First Road, Park Drive, Sri Lanka \n sales@buygrand.com\n\n");
        headerText.setAlignment(Element.ALIGN_CENTER);
        doc.add(headerText);
    }
    public void addLogo(Document doc) throws BadElementException, IOException, DocumentException
    {
        Image image  = Image.getInstance("Logo.png");
        image.setAlignment(Element.ALIGN_CENTER);
        doc.add(image);
    }
    public PdfPTable headerRow(PdfPTable table)
    {
        String[] cols = {"Product ID","Product Description","Quantity","Unit Price", "Total Price"};
        for (int i = 0; i < 5; i++) {
            PdfPCell cell = new PdfPCell(new Phrase(cols[i]));
            table.addCell(cell);
        }
        table.completeRow();
        return table;
    }
    public PdfPTable getData(String username,PdfPTable table) throws SQLException
    {
        PopulateCart pc = new PopulateCart();
        ResultSet rs = pc.populate(username);
        String [][] data = new String [pc.getRowCount(username)][5];
        int rowCount = 0;
        while(rs.next())
        {
            data[rowCount][0] = rs.getString(1);
            data[rowCount][1] = rs.getString(2);
            data[rowCount][2] = Integer.toString(rs.getInt(3));
            data[rowCount][3] = Double.toString(rs.getDouble(3));
            data[rowCount][4] = Double.toString(rs.getDouble(3));
            rowCount++;
        }
        return fillRows(username,rowCount,data,table);
    }
    public PdfPTable fillRows(String username,int rowCount,String [][]data,PdfPTable table)
    {
        double totalPrice  = 0;
        for (int i = 0; i < rowCount; i++) {
            for(int j = 0; j < 5; j++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(data[i][j]));
                cell.setBorder(Rectangle.NO_BORDER);
                table.addCell(cell);
                if(j==4)
                {
                    totalPrice+= Double.parseDouble(data[i][j]);
                }
            }
            table.completeRow();
        }
        table.completeRow();
        this.setTotalPrice(totalPrice);
        return table;
    }
    public PdfPTable footerRow(PdfPTable table)
    {
        PdfPCell blankCell = new PdfPCell(new Phrase(""));
        blankCell.setBorder(Rectangle.NO_BORDER);
        table.addCell(blankCell);
        table.addCell(blankCell);
        table.addCell(blankCell);
        PdfPCell subtotalDesc = new PdfPCell(new Phrase("Sub Total:"));
        PdfPCell subtotalValue = new PdfPCell(new Phrase(Double.toString(this.getTotalPrice())));
        subtotalDesc.setBorder(Rectangle.NO_BORDER);
        subtotalValue.setBorder(Rectangle.NO_BORDER);
        table.addCell(subtotalDesc);
        table.addCell(subtotalValue);
        table.completeRow();
        return table;
    }
    public void table(Document doc, File file, String username) throws FileNotFoundException, DocumentException, SQLException
    {
        PdfPTable table = new PdfPTable(5);
        
        table = headerRow(table);
        table = getData(username,table);
        table = footerRow(table);
        
        doc.add(table);
    }
    public void signature(Document doc) throws BadElementException, IOException, DocumentException
    {
        Paragraph p = new Paragraph("\n\nThe following is a generated digital signature of the user. No sign in required.");
        Image image  = Image.getInstance("submitted_image.png");
        doc.add(p);
        doc.add(image);
    }
}
