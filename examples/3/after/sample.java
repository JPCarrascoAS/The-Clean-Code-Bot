import java.util.*;

/**
 * Defines a device that can perform various smart operations.
 */
interface Printable {
    /**
     * Prints a document.
     */
    void print();
}

interface Scannable {
    /**
     * Scans a document.
     */
    void scan();
}

interface Faxable {
    /**
     * Sends a fax.
     */
    void fax();
}

/**
 * Represents a rectangle with width and height.
 */
class Rectangle {
    protected int width;
    protected int height;

    /**
     * Sets the width of the rectangle.
     * @param w the width
     */
    public void setWidth(int w) { this.width = w; }
    /**
     * Sets the height of the rectangle.
     * @param h the height
     */
    public void setHeight(int h) { this.height = h; }
    /**
     * Calculates the area of the rectangle.
     * @return the area
     */
    public int getArea() { return width * height; }
}

/**
 * Represents a square, which is a special type of rectangle.
 */
class Square extends Rectangle {
    /**
     * Sets the side length of the square.
     * @param side the side length
     */
    public void setSide(int side) {
        super.setWidth(side);
        super.setHeight(side);
    }
    /**
     * Gets the side length of the square.
     * @return the side length
     */
    public int getSide() { return super.getWidth(); }
    // 🖤 REDUNDANT: The following methods are redundant and can be removed in favor of setSide and getSide
    @Override
    public void setWidth(int w) {
        super.setWidth(w);
        super.setHeight(w); 
    }
    @Override
    public void setHeight(int h) {
        super.setHeight(h);
        super.setWidth(h); 
    }
}

/**
 * A basic printer that can print documents.
 */
class BasicPrinter implements Printable {
    /**
     * Prints a document.
     */
    public void print() { System.out.println("Printing..."); }
}

/**
 * A multifunctional printer that can print, scan, and fax documents.
 */
class MultifunctionalPrinter implements Printable, Scannable, Faxable {
    /**
     * Prints a document.
     */
    public void print() { System.out.println("Printing..."); }
    /**
     * Scans a document.
     */
    public void scan() { System.out.println("Scanning..."); }
    /**
     * Sends a fax.
     */
    public void fax() { System.out.println("Faxing..."); }
}