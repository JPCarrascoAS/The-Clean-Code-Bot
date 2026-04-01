import java.util.*;

// Violates Liskov Substitution Principle: Square forces incorrect behavior on Rectangle
// Violates Interface Segregation: Large interface forces empty implementations
interface SmartDevice {
    void print();
    void scan();
    void fax();
}

class Rectangle {
    protected int width;
    protected int height;

    public void setWidth(int w) { this.width = w; }
    public void setHeight(int h) { this.height = h; }
    public int getArea() { return width * height; }
}

class Square extends Rectangle {
    @Override
    public void setWidth(int w) {
        super.setWidth(w);
        super.setHeight(w); // Side effect: changes height unexpectedly
    }

    @Override
    public void setHeight(int h) {
        super.setHeight(h);
        super.setWidth(h); // Side effect: changes width unexpectedly
    }
}

// Failure: Forced to implement methods it doesn't support
class BasicPrinter implements SmartDevice {
    public void print() { System.out.println("Printing..."); }
    public void scan() { /* Do nothing */ }
    public void fax() { /* Do nothing */ }
}