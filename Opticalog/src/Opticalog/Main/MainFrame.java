/**
 * @author Crypticsy
 */

package Opticalog.Main;


import java.awt.CardLayout;
import java.awt.Color;
import java.awt.Desktop;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.List;
import javax.swing.AbstractAction;
import javax.swing.BorderFactory;
import javax.swing.JComponent;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPasswordField;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.plaf.basic.BasicScrollBarUI;
import javax.swing.UIManager;
import javax.swing.filechooser.FileNameExtensionFilter;
import javax.swing.table.DefaultTableModel;



public class MainFrame extends javax.swing.JFrame {

    /**
     * Creates new form LoginFrame
     */
    
    // Initializing default paths
    private final String userDirectoryPath = "./src/Opticalog/Database/user_directory.csv";
    private final String catalogueDirectoryPath = "./src/Opticalog/Database/catalogue.csv";
    private final String helpPDFPath = "./src/Opticalog/Database/help.pdf";
    
    // Attributes for custom fonts
    private Font bauhaus, caviar, comforta, courier;
    
    // Initializing custom colors
    private final Color CustomSkyBlue = new java.awt.Color(77,131,169);
    private final Color CustomFadedWhite = new java.awt.Color(230,236,239);
    private final Color CustomBlack = new java.awt.Color(52,50,50);
    private final Color CustomFadedBlack = new java.awt.Color(95,95,95);
    
    // Attributes for the system
    private int mouseCord_x;
    private int mouseCord_y;
    private int userId;
    private String curFilePath ;
    private List<Integer> itemIndex;
    private List<Integer> searchIndexList;
    private List<String[]> itemDetails;
    private List<String[]> userDetails;
    private Algorithms algo;
    private CardLayout mainCardLayout;
    private CardLayout registrationCardLayout;
    private CardLayout itemCardLayout;
    
    
    
    public MainFrame() {
        
        // Importing custom fonts
        try{
            bauhaus = Font.createFont(Font.TRUETYPE_FONT, new FileInputStream(new File("./src/Opticalog/Fonts/bauhaus.ttf"))).deriveFont(Font.BOLD, 36);
            caviar = Font.createFont(Font.TRUETYPE_FONT, new FileInputStream(new File("./src/Opticalog/Fonts/caviardreams_bold.ttf"))).deriveFont(Font.BOLD, 16);
            comforta = Font.createFont(Font.TRUETYPE_FONT, new FileInputStream(new File("./src/Opticalog/Fonts/comfortaa_bold.ttf"))).deriveFont(Font.BOLD, 12);
            courier = Font.createFont(Font.TRUETYPE_FONT, new FileInputStream(new File("./src/Opticalog/Fonts/cour.ttf"))).deriveFont(Font.BOLD, 12);
        } catch(Exception e){
            e.printStackTrace();
        } 
        
        // Setting custom changes as detaults for the components
        UIManager.put("Button.font", comforta);
        UIManager.put("CheckBox.font", comforta);
        UIManager.put("ComboBox.font", comforta);
        UIManager.put("Label.font", caviar);
        UIManager.put("Menu.font", caviar);
        UIManager.put("MenuItem.font", caviar);
        UIManager.put("Table.font", comforta);
        UIManager.put("TextArea.font", comforta);
        UIManager.put("TextField.font", comforta);
        UIManager.put("Menu.foreground", CustomFadedWhite);
        UIManager.put("Menu.selectionBackground", CustomSkyBlue);
        UIManager.put("MenuBar.background", CustomBlack);
        UIManager.put("MenuItem.background", CustomFadedBlack);
        UIManager.put("MenuItem.foreground", CustomFadedWhite);
        UIManager.put("MenuItem.selectionBackground", CustomSkyBlue);
        UIManager.put("PopupMenu.border", CustomSkyBlue);
        UIManager.put("RadioButton.font", comforta);
        
        
        initComponents();
        
        // Initiate customization
        addMenuBar();
        addCustomization();
        
        // Initialize attributes for the system
        userId = -1;
        algo = new Algorithms();
        itemIndex = new ArrayList<>();
        searchIndexList = new ArrayList<>();
        itemDetails = new ArrayList<>();
        userDetails = new ArrayList<>();
        
        mainCardLayout = (CardLayout) mainContainer.getLayout();
        registrationCardLayout = (CardLayout) registrationContainer.getLayout();
        itemCardLayout = (CardLayout) servicesContainer.getLayout();
        
        // pre load the database
        loadUserDetails();
        hideAdminButtons();
        itemClear_btn.setVisible(false);
        
    }
    
    
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        sortButtonGroup = new javax.swing.ButtonGroup();
        categoryButtonGroup = new javax.swing.ButtonGroup();
        genderButtonGroup = new javax.swing.ButtonGroup();
        mainContainer = new javax.swing.JPanel();
        navigation_UI = new javax.swing.JPanel();
        opticalog_icon = new javax.swing.JLabel();
        copyright_lbl = new javax.swing.JLabel();
        exit_button = new javax.swing.JLabel();
        minimize_button = new javax.swing.JLabel();
        login_image = new javax.swing.JLabel();
        registrationContainer = new javax.swing.JPanel();
        loginCard = new javax.swing.JPanel();
        login_title = new javax.swing.JLabel();
        login_error_message = new javax.swing.JLabel();
        login_username_lbl = new javax.swing.JLabel();
        login_username_txtfield = new javax.swing.JTextField();
        login_password_lbl = new javax.swing.JLabel();
        login_btn = new javax.swing.JButton();
        login_switch_btn = new javax.swing.JButton();
        login_password_txtfield = new javax.swing.JPasswordField();
        signupCard = new javax.swing.JPanel();
        signup_title = new javax.swing.JLabel();
        signup_error_message = new javax.swing.JLabel();
        signup_username_lbl = new javax.swing.JLabel();
        signup_username_txtfield = new javax.swing.JTextField();
        signup_password_lbl = new javax.swing.JLabel();
        signup_btn = new javax.swing.JButton();
        signup_switch_btn = new javax.swing.JButton();
        signup_repassword_lbl = new javax.swing.JLabel();
        signup_repassword_txtfield = new javax.swing.JPasswordField();
        signup_password_txtfield = new javax.swing.JPasswordField();
        user_panel = new javax.swing.JPanel();
        welcomeUser_lbl = new javax.swing.JLabel();
        logout_btn = new javax.swing.JButton();
        sidePanel = new javax.swing.JPanel();
        footer_lbl = new javax.swing.JLabel();
        search_txtfield = new javax.swing.JTextField();
        commit_btn = new javax.swing.JButton();
        sort_chkbox = new javax.swing.JCheckBox();
        descending_btn = new javax.swing.JRadioButton();
        ascending_btn = new javax.swing.JRadioButton();
        filters_lbl = new javax.swing.JLabel();
        category_chkbox = new javax.swing.JCheckBox();
        name_btn = new javax.swing.JRadioButton();
        manufacturer_btn = new javax.swing.JRadioButton();
        material_btn = new javax.swing.JRadioButton();
        price_btn = new javax.swing.JRadioButton();
        type_btn = new javax.swing.JRadioButton();
        search_btn = new javax.swing.JButton();
        addItem_btn = new javax.swing.JButton();
        editItem_btn = new javax.swing.JButton();
        deleteItem_btn = new javax.swing.JButton();
        main_exit_button = new javax.swing.JLabel();
        main_minimize_button = new javax.swing.JLabel();
        user_icon = new javax.swing.JLabel();
        editUserProfile_btn = new javax.swing.JButton();
        servicesContainer = new javax.swing.JPanel();
        tableContainer = new javax.swing.JPanel();
        catalogueScroller = new javax.swing.JScrollPane();
        catalouge = new javax.swing.JTable();
        itemPannel = new javax.swing.JPanel();
        frameName_lbl = new javax.swing.JLabel();
        frameName_txtfield = new javax.swing.JTextField();
        itemClear_btn = new javax.swing.JButton();
        itemCancel_btn = new javax.swing.JButton();
        itemSave_btn = new javax.swing.JButton();
        manufacturer_txtfield = new javax.swing.JTextField();
        manufacturer_lbl = new javax.swing.JLabel();
        material_lbl = new javax.swing.JLabel();
        color_comboBox = new javax.swing.JComboBox<>();
        type_lbl = new javax.swing.JLabel();
        description_lbl = new javax.swing.JLabel();
        gender_lbl = new javax.swing.JLabel();
        color_lbl = new javax.swing.JLabel();
        price_lbl = new javax.swing.JLabel();
        price_txtfield = new javax.swing.JTextField();
        quantity_lbl = new javax.swing.JLabel();
        quantity_txtfield = new javax.swing.JTextField();
        material_comboBox = new javax.swing.JComboBox<>();
        type_comboBox = new javax.swing.JComboBox<>();
        jScrollPane1 = new javax.swing.JScrollPane();
        description_textArea = new javax.swing.JTextArea();
        female_btn = new javax.swing.JRadioButton();
        unisex_btn = new javax.swing.JRadioButton();
        male_btn = new javax.swing.JRadioButton();
        aboutUsPanel = new javax.swing.JPanel();
        backToMain_btn = new javax.swing.JButton();
        aboutUs_description_lbl = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Opticalog");
        setUndecorated(true);
        setResizable(false);

        mainContainer.addMouseMotionListener(new java.awt.event.MouseMotionAdapter() {
            public void mouseDragged(java.awt.event.MouseEvent evt) {
                mainContainerMouseDragged(evt);
            }
        });
        mainContainer.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mousePressed(java.awt.event.MouseEvent evt) {
                mainContainerMousePressed(evt);
            }
        });
        mainContainer.setLayout(new java.awt.CardLayout());

        navigation_UI.setBackground(new java.awt.Color(52, 50, 50));
        navigation_UI.setMaximumSize(new java.awt.Dimension(1050, 750));
        navigation_UI.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        opticalog_icon.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Opticalog/Image/opticalog_icon_small.png"))); // NOI18N
        navigation_UI.add(opticalog_icon, new org.netbeans.lib.awtextra.AbsoluteConstraints(160, 40, -1, -1));

        copyright_lbl.setFont(new java.awt.Font("Courier New", 1, 12)); // NOI18N
        copyright_lbl.setForeground(new java.awt.Color(230, 236, 239));
        copyright_lbl.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        copyright_lbl.setText("© 2020 Opticalog");
        navigation_UI.add(copyright_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(130, 720, 120, -1));

        exit_button.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Opticalog/Image/exit_icon.png"))); // NOI18N
        exit_button.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        exit_button.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                exit_buttonMouseClicked(evt);
            }
        });
        navigation_UI.add(exit_button, new org.netbeans.lib.awtextra.AbsoluteConstraints(1010, 10, -1, -1));

        minimize_button.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Opticalog/Image/minimize_icon.png"))); // NOI18N
        minimize_button.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        minimize_button.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                minimize_buttonMouseClicked(evt);
            }
        });
        navigation_UI.add(minimize_button, new org.netbeans.lib.awtextra.AbsoluteConstraints(980, 10, -1, -1));

        login_image.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Opticalog/Image/opticalog_login.png"))); // NOI18N
        navigation_UI.add(login_image, new org.netbeans.lib.awtextra.AbsoluteConstraints(400, 0, 650, -1));

        registrationContainer.setLayout(new java.awt.CardLayout());

        loginCard.setBackground(new java.awt.Color(52, 50, 50));
        loginCard.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        login_title.setForeground(new java.awt.Color(230, 236, 239));
        login_title.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        login_title.setText("Log in");
        loginCard.add(login_title, new org.netbeans.lib.awtextra.AbsoluteConstraints(140, 40, 130, -1));

        login_error_message.setFont(new java.awt.Font("Comfortaa Light", 1, 12)); // NOI18N
        login_error_message.setForeground(new java.awt.Color(221, 80, 80));
        loginCard.add(login_error_message, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 330, 210, -1));

        login_username_lbl.setForeground(new java.awt.Color(230, 236, 239));
        login_username_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        login_username_lbl.setText("Username :");
        loginCard.add(login_username_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 140, 110, 20));

        login_username_txtfield.setBackground(new java.awt.Color(102, 102, 102));
        login_username_txtfield.setForeground(new java.awt.Color(230, 236, 239));
        login_username_txtfield.setBorder(null);
        login_username_txtfield.setCaretColor(new java.awt.Color(230, 236, 239));
        loginCard.add(login_username_txtfield, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 170, 280, 30));

        login_password_lbl.setForeground(new java.awt.Color(230, 236, 239));
        login_password_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        login_password_lbl.setText("Password :");
        loginCard.add(login_password_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 220, 110, 20));

        login_btn.setBackground(new java.awt.Color(72, 141, 188));
        login_btn.setForeground(new java.awt.Color(230, 236, 239));
        login_btn.setText("Log In");
        login_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        login_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        login_btn.setFocusPainted(false);
        login_btn.setFocusable(false);
        login_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                login_btnActionPerformed(evt);
            }
        });
        loginCard.add(login_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(160, 450, 80, 30));

        login_switch_btn.setBackground(new java.awt.Color(52, 50, 50));
        login_switch_btn.setForeground(new java.awt.Color(72, 141, 188));
        login_switch_btn.setText("Not Registered Yet? Register Here");
        login_switch_btn.setBorder(null);
        login_switch_btn.setBorderPainted(false);
        login_switch_btn.setContentAreaFilled(false);
        login_switch_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        login_switch_btn.setFocusPainted(false);
        login_switch_btn.setFocusable(false);
        login_switch_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                login_switch_btnActionPerformed(evt);
            }
        });
        loginCard.add(login_switch_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(80, 490, 240, 30));

        login_password_txtfield.setBackground(new java.awt.Color(102, 102, 102));
        login_password_txtfield.setForeground(new java.awt.Color(230, 236, 239));
        login_password_txtfield.setBorder(null);
        login_password_txtfield.setCaretColor(new java.awt.Color(230, 236, 239));
        login_password_txtfield.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyPressed(java.awt.event.KeyEvent evt) {
                login_password_txtfieldKeyPressed(evt);
            }
        });
        loginCard.add(login_password_txtfield, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 250, 280, 30));

        registrationContainer.add(loginCard, "loginCard");

        signupCard.setBackground(new java.awt.Color(52, 50, 50));
        signupCard.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        signup_title.setForeground(new java.awt.Color(230, 236, 239));
        signup_title.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        signup_title.setText("Sign up");
        signupCard.add(signup_title, new org.netbeans.lib.awtextra.AbsoluteConstraints(140, 40, 130, -1));

        signup_error_message.setForeground(new java.awt.Color(221, 80, 80));
        signup_error_message.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        signupCard.add(signup_error_message, new org.netbeans.lib.awtextra.AbsoluteConstraints(40, 390, 320, -1));

        signup_username_lbl.setForeground(new java.awt.Color(230, 236, 239));
        signup_username_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        signup_username_lbl.setText("Username :");
        signupCard.add(signup_username_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 140, 110, 20));

        signup_username_txtfield.setBackground(new java.awt.Color(102, 102, 102));
        signup_username_txtfield.setForeground(new java.awt.Color(230, 236, 239));
        signup_username_txtfield.setBorder(null);
        signup_username_txtfield.setCaretColor(new java.awt.Color(230, 236, 239));
        signupCard.add(signup_username_txtfield, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 170, 280, 30));

        signup_password_lbl.setForeground(new java.awt.Color(230, 236, 239));
        signup_password_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        signup_password_lbl.setText("Password :");
        signupCard.add(signup_password_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 220, 110, 20));

        signup_btn.setBackground(new java.awt.Color(72, 141, 188));
        signup_btn.setForeground(new java.awt.Color(230, 236, 239));
        signup_btn.setText("Sign Up");
        signup_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        signup_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        signup_btn.setFocusPainted(false);
        signup_btn.setFocusable(false);
        signup_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                signup_btnActionPerformed(evt);
            }
        });
        signupCard.add(signup_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(160, 450, 80, 30));

        signup_switch_btn.setBackground(new java.awt.Color(52, 50, 50));
        signup_switch_btn.setForeground(new java.awt.Color(72, 141, 188));
        signup_switch_btn.setText("Already have an account? Log in Here");
        signup_switch_btn.setBorder(null);
        signup_switch_btn.setBorderPainted(false);
        signup_switch_btn.setContentAreaFilled(false);
        signup_switch_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        signup_switch_btn.setFocusPainted(false);
        signup_switch_btn.setFocusable(false);
        signup_switch_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                signup_switch_btnActionPerformed(evt);
            }
        });
        signupCard.add(signup_switch_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(70, 490, 270, 30));

        signup_repassword_lbl.setForeground(new java.awt.Color(230, 236, 239));
        signup_repassword_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        signup_repassword_lbl.setText("Re-Type Password :");
        signupCard.add(signup_repassword_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 300, 160, 20));

        signup_repassword_txtfield.setBackground(new java.awt.Color(102, 102, 102));
        signup_repassword_txtfield.setFont(new java.awt.Font("Comfortaa Light", 0, 12)); // NOI18N
        signup_repassword_txtfield.setForeground(new java.awt.Color(230, 236, 239));
        signup_repassword_txtfield.setBorder(null);
        signup_repassword_txtfield.setCaretColor(new java.awt.Color(230, 236, 239));
        signupCard.add(signup_repassword_txtfield, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 330, 280, 30));

        signup_password_txtfield.setBackground(new java.awt.Color(102, 102, 102));
        signup_password_txtfield.setFont(new java.awt.Font("Comfortaa Light", 0, 12)); // NOI18N
        signup_password_txtfield.setForeground(new java.awt.Color(230, 236, 239));
        signup_password_txtfield.setBorder(null);
        signup_password_txtfield.setCaretColor(new java.awt.Color(230, 236, 239));
        signupCard.add(signup_password_txtfield, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 250, 280, 30));

        registrationContainer.add(signupCard, "signupCard");

        navigation_UI.add(registrationContainer, new org.netbeans.lib.awtextra.AbsoluteConstraints(0, 130, 400, 570));
        registrationContainer.getAccessibleContext().setAccessibleName("registration");

        mainContainer.add(navigation_UI, "navigation");

        user_panel.setBackground(new java.awt.Color(230, 236, 239));
        user_panel.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        welcomeUser_lbl.setBackground(new java.awt.Color(230, 236, 239));
        welcomeUser_lbl.setFont(new java.awt.Font("Dialog", 1, 24)); // NOI18N
        welcomeUser_lbl.setForeground(new java.awt.Color(77, 131, 169));
        welcomeUser_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        welcomeUser_lbl.setText("Welcome, ");
        user_panel.add(welcomeUser_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(470, 50, 400, -1));

        logout_btn.setBackground(new java.awt.Color(77, 131, 169));
        logout_btn.setForeground(new java.awt.Color(230, 236, 239));
        logout_btn.setText("Log Out");
        logout_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        logout_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        logout_btn.setFocusPainted(false);
        logout_btn.setFocusable(false);
        logout_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                logout_btnActionPerformed(evt);
            }
        });
        user_panel.add(logout_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(950, 90, 80, 30));

        sidePanel.setBackground(new java.awt.Color(52, 50, 50));
        sidePanel.setPreferredSize(new java.awt.Dimension(340, 520));
        sidePanel.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        footer_lbl.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Opticalog/Image/opticalog_icon_full.png"))); // NOI18N
        footer_lbl.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mousePressed(java.awt.event.MouseEvent evt) {
                footer_lblMousePressed(evt);
            }
        });
        sidePanel.add(footer_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(90, 660, -1, -1));

        search_txtfield.setBackground(new java.awt.Color(102, 102, 102));
        search_txtfield.setFont(new java.awt.Font("Comfortaa Light", 0, 12)); // NOI18N
        search_txtfield.setForeground(new java.awt.Color(230, 236, 239));
        search_txtfield.setBorder(null);
        search_txtfield.setCaretColor(new java.awt.Color(230, 236, 239));
        search_txtfield.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyPressed(java.awt.event.KeyEvent evt) {
                search_txtfieldKeyPressed(evt);
            }
        });
        sidePanel.add(search_txtfield, new org.netbeans.lib.awtextra.AbsoluteConstraints(30, 130, 210, 30));

        commit_btn.setBackground(new java.awt.Color(72, 141, 188));
        commit_btn.setForeground(new java.awt.Color(230, 236, 239));
        commit_btn.setText("Commit Changes");
        commit_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        commit_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        commit_btn.setFocusPainted(false);
        commit_btn.setFocusable(false);
        commit_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                commit_btnActionPerformed(evt);
            }
        });
        sidePanel.add(commit_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 580, 170, 30));

        sort_chkbox.setBackground(new java.awt.Color(52, 50, 50));
        sort_chkbox.setForeground(new java.awt.Color(230, 236, 239));
        sort_chkbox.setText("Sort");
        sort_chkbox.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        sort_chkbox.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        sort_chkbox.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                sort_chkboxActionPerformed(evt);
            }
        });
        sidePanel.add(sort_chkbox, new org.netbeans.lib.awtextra.AbsoluteConstraints(190, 240, 70, -1));

        descending_btn.setBackground(new java.awt.Color(52, 50, 50));
        sortButtonGroup.add(descending_btn);
        descending_btn.setForeground(new java.awt.Color(230, 236, 239));
        descending_btn.setText("Descending");
        descending_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        descending_btn.setEnabled(false);
        descending_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                descending_btnActionPerformed(evt);
            }
        });
        sidePanel.add(descending_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(200, 300, -1, -1));

        ascending_btn.setBackground(new java.awt.Color(52, 50, 50));
        sortButtonGroup.add(ascending_btn);
        ascending_btn.setForeground(new java.awt.Color(230, 236, 239));
        ascending_btn.setText("Ascending");
        ascending_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        ascending_btn.setEnabled(false);
        ascending_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                ascending_btnActionPerformed(evt);
            }
        });
        sidePanel.add(ascending_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(200, 270, -1, -1));

        filters_lbl.setForeground(new java.awt.Color(230, 236, 239));
        filters_lbl.setText("Filters");
        sidePanel.add(filters_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(150, 200, -1, -1));

        category_chkbox.setBackground(new java.awt.Color(52, 50, 50));
        category_chkbox.setForeground(new java.awt.Color(230, 236, 239));
        category_chkbox.setText("Category");
        category_chkbox.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        category_chkbox.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        category_chkbox.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                category_chkboxActionPerformed(evt);
            }
        });
        sidePanel.add(category_chkbox, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 240, 100, -1));

        name_btn.setBackground(new java.awt.Color(52, 50, 50));
        categoryButtonGroup.add(name_btn);
        name_btn.setForeground(new java.awt.Color(230, 236, 239));
        name_btn.setText("Name");
        name_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        name_btn.setEnabled(false);
        name_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                name_btnActionPerformed(evt);
            }
        });
        sidePanel.add(name_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(70, 270, -1, -1));

        manufacturer_btn.setBackground(new java.awt.Color(52, 50, 50));
        categoryButtonGroup.add(manufacturer_btn);
        manufacturer_btn.setForeground(new java.awt.Color(230, 236, 239));
        manufacturer_btn.setText("Manufacturer");
        manufacturer_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        manufacturer_btn.setEnabled(false);
        manufacturer_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                manufacturer_btnActionPerformed(evt);
            }
        });
        sidePanel.add(manufacturer_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(70, 300, -1, -1));

        material_btn.setBackground(new java.awt.Color(52, 50, 50));
        categoryButtonGroup.add(material_btn);
        material_btn.setForeground(new java.awt.Color(230, 236, 239));
        material_btn.setText("Material");
        material_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        material_btn.setEnabled(false);
        material_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                material_btnActionPerformed(evt);
            }
        });
        sidePanel.add(material_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(70, 330, -1, -1));

        price_btn.setBackground(new java.awt.Color(52, 50, 50));
        categoryButtonGroup.add(price_btn);
        price_btn.setForeground(new java.awt.Color(230, 236, 239));
        price_btn.setText("Price");
        price_btn.setToolTipText("");
        price_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        price_btn.setEnabled(false);
        price_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                price_btnActionPerformed(evt);
            }
        });
        sidePanel.add(price_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(70, 390, -1, -1));

        type_btn.setBackground(new java.awt.Color(52, 50, 50));
        categoryButtonGroup.add(type_btn);
        type_btn.setForeground(new java.awt.Color(230, 236, 239));
        type_btn.setText("Type");
        type_btn.setToolTipText("");
        type_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        type_btn.setEnabled(false);
        type_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                type_btnActionPerformed(evt);
            }
        });
        sidePanel.add(type_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(70, 360, -1, -1));

        search_btn.setBackground(new java.awt.Color(72, 141, 188));
        search_btn.setForeground(new java.awt.Color(230, 236, 239));
        search_btn.setText("Search");
        search_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        search_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        search_btn.setFocusPainted(false);
        search_btn.setFocusable(false);
        search_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                search_btnActionPerformed(evt);
            }
        });
        sidePanel.add(search_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(250, 130, 70, 30));

        addItem_btn.setBackground(new java.awt.Color(72, 141, 188));
        addItem_btn.setForeground(new java.awt.Color(230, 236, 239));
        addItem_btn.setText("Add a New Item");
        addItem_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        addItem_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        addItem_btn.setFocusPainted(false);
        addItem_btn.setFocusable(false);
        addItem_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                addItem_btnActionPerformed(evt);
            }
        });
        sidePanel.add(addItem_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 460, 170, 30));

        editItem_btn.setBackground(new java.awt.Color(72, 141, 188));
        editItem_btn.setForeground(new java.awt.Color(230, 236, 239));
        editItem_btn.setText("Edit Item");
        editItem_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        editItem_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        editItem_btn.setFocusPainted(false);
        editItem_btn.setFocusable(false);
        editItem_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                editItem_btnActionPerformed(evt);
            }
        });
        sidePanel.add(editItem_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 500, 170, 30));

        deleteItem_btn.setBackground(new java.awt.Color(72, 141, 188));
        deleteItem_btn.setForeground(new java.awt.Color(230, 236, 239));
        deleteItem_btn.setText("Delete Item");
        deleteItem_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        deleteItem_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        deleteItem_btn.setFocusPainted(false);
        deleteItem_btn.setFocusable(false);
        deleteItem_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                deleteItem_btnActionPerformed(evt);
            }
        });
        sidePanel.add(deleteItem_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 540, 170, 30));

        user_panel.add(sidePanel, new org.netbeans.lib.awtextra.AbsoluteConstraints(0, 0, -1, 750));

        main_exit_button.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Opticalog/Image/exit_icon_b.png"))); // NOI18N
        main_exit_button.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        main_exit_button.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                main_exit_buttonMouseClicked(evt);
            }
        });
        user_panel.add(main_exit_button, new org.netbeans.lib.awtextra.AbsoluteConstraints(1010, 10, -1, -1));

        main_minimize_button.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Opticalog/Image/minimize_icon_b.png"))); // NOI18N
        main_minimize_button.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        main_minimize_button.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                main_minimize_buttonMouseClicked(evt);
            }
        });
        user_panel.add(main_minimize_button, new org.netbeans.lib.awtextra.AbsoluteConstraints(980, 10, -1, -1));

        user_icon.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Opticalog/Image/user_icon.png"))); // NOI18N
        user_panel.add(user_icon, new org.netbeans.lib.awtextra.AbsoluteConstraints(380, 40, -1, -1));

        editUserProfile_btn.setBackground(new java.awt.Color(52, 50, 50));
        editUserProfile_btn.setForeground(new java.awt.Color(72, 141, 188));
        editUserProfile_btn.setText("Edit profile");
        editUserProfile_btn.setBorder(null);
        editUserProfile_btn.setBorderPainted(false);
        editUserProfile_btn.setContentAreaFilled(false);
        editUserProfile_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        editUserProfile_btn.setFocusPainted(false);
        editUserProfile_btn.setFocusable(false);
        editUserProfile_btn.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        editUserProfile_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                editUserProfile_btnActionPerformed(evt);
            }
        });
        user_panel.add(editUserProfile_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(470, 80, 80, 20));

        servicesContainer.setLayout(new java.awt.CardLayout());

        tableContainer.setBackground(new java.awt.Color(230, 236, 239));
        tableContainer.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        catalogueScroller.setBackground(new java.awt.Color(77, 131, 169));
        catalogueScroller.setBorder(null);
        catalogueScroller.setForeground(new java.awt.Color(77, 131, 169));
        catalogueScroller.setColumnHeaderView(null);
        catalogueScroller.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));

        catalouge.setBackground(new java.awt.Color(230, 236, 239));
        catalouge.setForeground(new java.awt.Color(52, 50, 50));
        catalouge.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {"102", "Sun glasses", "Omegal", "500", null},
                {"293", "Concaves", "Hebrew", "600", null},
                {"394", "Black Shades", "Samsmith", null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null},
                {null, null, null, null, null}
            },
            new String [] {
                "Name", "Manufacturer", "Material", "Type", "Price"
            }
        ) {
            boolean[] canEdit = new boolean [] {
                false, false, false, false, false
            };

            public boolean isCellEditable(int rowIndex, int columnIndex) {
                return canEdit [columnIndex];
            }
        });
        catalouge.setFocusable(false);
        catalouge.setGridColor(new java.awt.Color(69, 74, 88));
        catalouge.setRowHeight(35);
        catalouge.setRowMargin(2);
        catalouge.setSelectionMode(javax.swing.ListSelectionModel.SINGLE_SELECTION);
        catalouge.setShowGrid(true);
        catalouge.getTableHeader().setReorderingAllowed(false);
        catalogueScroller.setViewportView(catalouge);
        if (catalouge.getColumnModel().getColumnCount() > 0) {
            catalouge.getColumnModel().getColumn(0).setResizable(false);
            catalouge.getColumnModel().getColumn(1).setResizable(false);
            catalouge.getColumnModel().getColumn(2).setResizable(false);
            catalouge.getColumnModel().getColumn(3).setResizable(false);
            catalouge.getColumnModel().getColumn(4).setResizable(false);
        }

        tableContainer.add(catalogueScroller, new org.netbeans.lib.awtextra.AbsoluteConstraints(10, 10, 660, 580));

        servicesContainer.add(tableContainer, "tableCard");

        itemPannel.setBackground(new java.awt.Color(230, 236, 239));
        itemPannel.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        frameName_lbl.setBackground(new java.awt.Color(230, 236, 239));
        frameName_lbl.setForeground(new java.awt.Color(52, 50, 50));
        frameName_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        frameName_lbl.setText("Frame Name :");
        itemPannel.add(frameName_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 50, 120, 20));

        frameName_txtfield.setBackground(new java.awt.Color(153, 153, 153));
        frameName_txtfield.setForeground(new java.awt.Color(230, 236, 239));
        frameName_txtfield.setBorder(null);
        frameName_txtfield.setCaretColor(new java.awt.Color(230, 236, 239));
        itemPannel.add(frameName_txtfield, new org.netbeans.lib.awtextra.AbsoluteConstraints(230, 50, 280, 30));

        itemClear_btn.setBackground(new java.awt.Color(72, 141, 188));
        itemClear_btn.setForeground(new java.awt.Color(230, 236, 239));
        itemClear_btn.setText("Clear");
        itemClear_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        itemClear_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        itemClear_btn.setFocusPainted(false);
        itemClear_btn.setFocusable(false);
        itemClear_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                itemClear_btnActionPerformed(evt);
            }
        });
        itemPannel.add(itemClear_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(380, 550, 90, 30));

        itemCancel_btn.setBackground(new java.awt.Color(72, 141, 188));
        itemCancel_btn.setForeground(new java.awt.Color(230, 236, 239));
        itemCancel_btn.setText("Cancel");
        itemCancel_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        itemCancel_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        itemCancel_btn.setFocusPainted(false);
        itemCancel_btn.setFocusable(false);
        itemCancel_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                itemCancel_btnActionPerformed(evt);
            }
        });
        itemPannel.add(itemCancel_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(580, 550, 90, 30));

        itemSave_btn.setBackground(new java.awt.Color(72, 141, 188));
        itemSave_btn.setForeground(new java.awt.Color(230, 236, 239));
        itemSave_btn.setText("Save");
        itemSave_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        itemSave_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        itemSave_btn.setFocusPainted(false);
        itemSave_btn.setFocusable(false);
        itemSave_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                itemSave_btnActionPerformed(evt);
            }
        });
        itemPannel.add(itemSave_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(480, 550, 90, 30));

        manufacturer_txtfield.setBackground(new java.awt.Color(153, 153, 153));
        manufacturer_txtfield.setForeground(new java.awt.Color(230, 236, 239));
        manufacturer_txtfield.setBorder(null);
        manufacturer_txtfield.setCaretColor(new java.awt.Color(230, 236, 239));
        itemPannel.add(manufacturer_txtfield, new org.netbeans.lib.awtextra.AbsoluteConstraints(230, 100, 280, 30));

        manufacturer_lbl.setBackground(new java.awt.Color(230, 236, 239));
        manufacturer_lbl.setForeground(new java.awt.Color(52, 50, 50));
        manufacturer_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        manufacturer_lbl.setText("Manufacturer :");
        itemPannel.add(manufacturer_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 100, 120, 20));

        material_lbl.setBackground(new java.awt.Color(230, 236, 239));
        material_lbl.setForeground(new java.awt.Color(52, 50, 50));
        material_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        material_lbl.setText("Material :");
        itemPannel.add(material_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 150, 120, 20));

        color_comboBox.setBackground(new java.awt.Color(153, 153, 153));
        color_comboBox.setForeground(new java.awt.Color(230, 236, 239));
        color_comboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Select", "Black", "Blue", "Brown", "Gold", "Red", "Silver", "Yellow" }));
        color_comboBox.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        itemPannel.add(color_comboBox, new org.netbeans.lib.awtextra.AbsoluteConstraints(230, 250, 280, 30));

        type_lbl.setBackground(new java.awt.Color(230, 236, 239));
        type_lbl.setForeground(new java.awt.Color(52, 50, 50));
        type_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        type_lbl.setText("Type :");
        itemPannel.add(type_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 200, 120, 20));

        description_lbl.setBackground(new java.awt.Color(230, 236, 239));
        description_lbl.setForeground(new java.awt.Color(52, 50, 50));
        description_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        description_lbl.setText("Description :");
        itemPannel.add(description_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 400, 120, 20));

        gender_lbl.setBackground(new java.awt.Color(230, 236, 239));
        gender_lbl.setForeground(new java.awt.Color(52, 50, 50));
        gender_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        gender_lbl.setText("Gender :");
        itemPannel.add(gender_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 350, 120, 20));

        color_lbl.setBackground(new java.awt.Color(230, 236, 239));
        color_lbl.setForeground(new java.awt.Color(52, 50, 50));
        color_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        color_lbl.setText("Color :");
        itemPannel.add(color_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 250, 90, 20));

        price_lbl.setBackground(new java.awt.Color(230, 236, 239));
        price_lbl.setForeground(new java.awt.Color(52, 50, 50));
        price_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        price_lbl.setText("Price :");
        itemPannel.add(price_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(100, 300, 60, 20));

        price_txtfield.setBackground(new java.awt.Color(153, 153, 153));
        price_txtfield.setForeground(new java.awt.Color(230, 236, 239));
        price_txtfield.setBorder(null);
        price_txtfield.setCaretColor(new java.awt.Color(230, 236, 239));
        itemPannel.add(price_txtfield, new org.netbeans.lib.awtextra.AbsoluteConstraints(160, 300, 110, 30));

        quantity_lbl.setBackground(new java.awt.Color(230, 236, 239));
        quantity_lbl.setForeground(new java.awt.Color(52, 50, 50));
        quantity_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        quantity_lbl.setText("Quantity :");
        itemPannel.add(quantity_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(330, 300, 90, 20));

        quantity_txtfield.setBackground(new java.awt.Color(153, 153, 153));
        quantity_txtfield.setForeground(new java.awt.Color(230, 236, 239));
        quantity_txtfield.setBorder(null);
        quantity_txtfield.setCaretColor(new java.awt.Color(230, 236, 239));
        itemPannel.add(quantity_txtfield, new org.netbeans.lib.awtextra.AbsoluteConstraints(420, 300, 110, 30));

        material_comboBox.setBackground(new java.awt.Color(153, 153, 153));
        material_comboBox.setForeground(new java.awt.Color(230, 236, 239));
        material_comboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Select", "Magnesium", "Nickel", "Plastic", "Rubber", "Stainless Steel", "Titanium" }));
        material_comboBox.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        itemPannel.add(material_comboBox, new org.netbeans.lib.awtextra.AbsoluteConstraints(230, 150, 280, 30));

        type_comboBox.setBackground(new java.awt.Color(153, 153, 153));
        type_comboBox.setForeground(new java.awt.Color(230, 236, 239));
        type_comboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Select", "Aviator", "Browline", "Goggles", "Rimless" }));
        type_comboBox.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        itemPannel.add(type_comboBox, new org.netbeans.lib.awtextra.AbsoluteConstraints(230, 200, 280, 30));

        description_textArea.setBackground(new java.awt.Color(153, 153, 153));
        description_textArea.setColumns(20);
        description_textArea.setForeground(new java.awt.Color(230, 236, 239));
        description_textArea.setRows(5);
        description_textArea.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        jScrollPane1.setViewportView(description_textArea);

        itemPannel.add(jScrollPane1, new org.netbeans.lib.awtextra.AbsoluteConstraints(230, 400, 280, 100));

        female_btn.setBackground(new java.awt.Color(230, 236, 239));
        genderButtonGroup.add(female_btn);
        female_btn.setForeground(new java.awt.Color(52, 50, 50));
        female_btn.setText("Female");
        female_btn.setActionCommand("Female");
        itemPannel.add(female_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(450, 350, -1, -1));

        unisex_btn.setBackground(new java.awt.Color(230, 236, 239));
        genderButtonGroup.add(unisex_btn);
        unisex_btn.setForeground(new java.awt.Color(52, 50, 50));
        unisex_btn.setText("Unisex");
        unisex_btn.setActionCommand("Unisex");
        itemPannel.add(unisex_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(230, 350, -1, -1));

        male_btn.setBackground(new java.awt.Color(230, 236, 239));
        genderButtonGroup.add(male_btn);
        male_btn.setForeground(new java.awt.Color(52, 50, 50));
        male_btn.setText("Male");
        male_btn.setActionCommand("Male");
        itemPannel.add(male_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(340, 350, -1, -1));

        servicesContainer.add(itemPannel, "itemCard");

        aboutUsPanel.setBackground(new java.awt.Color(230, 236, 239));
        aboutUsPanel.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        backToMain_btn.setBackground(new java.awt.Color(72, 141, 188));
        backToMain_btn.setForeground(new java.awt.Color(230, 236, 239));
        backToMain_btn.setText("Back");
        backToMain_btn.setBorder(javax.swing.BorderFactory.createCompoundBorder());
        backToMain_btn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        backToMain_btn.setFocusPainted(false);
        backToMain_btn.setFocusable(false);
        backToMain_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                backToMain_btnActionPerformed(evt);
            }
        });
        aboutUsPanel.add(backToMain_btn, new org.netbeans.lib.awtextra.AbsoluteConstraints(580, 550, 90, 30));

        aboutUs_description_lbl.setBackground(new java.awt.Color(230, 236, 239));
        aboutUs_description_lbl.setForeground(new java.awt.Color(52, 50, 50));
        aboutUs_description_lbl.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        aboutUs_description_lbl.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Opticalog/Image/opticalog_about_us.png"))); // NOI18N
        aboutUsPanel.add(aboutUs_description_lbl, new org.netbeans.lib.awtextra.AbsoluteConstraints(0, 0, 680, 600));

        servicesContainer.add(aboutUsPanel, "aboutUsCard");

        user_panel.add(servicesContainer, new org.netbeans.lib.awtextra.AbsoluteConstraints(360, 130, 680, 600));

        mainContainer.add(user_panel, "userCard");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(mainContainer, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(mainContainer, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
        );

        pack();
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    
    
    private void login_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_login_btnActionPerformed
        String username = login_username_txtfield.getText().trim();
        String password = new String(login_password_txtfield.getPassword()).trim();
        
        boolean invalid = true;
        String accessType = "";

        for(int i=0; i < userDetails.size();i++){
            if (userDetails.get(i)[0].equals(username) && userDetails.get(i)[1].equals(password)) {
                
                clearLoginCardFields();
                
                userId = i;
                algo.setSortOrder(-1);
                algo.setCategory(-1);
                
                curFilePath = catalogueDirectoryPath;
                loadItemDetails();
                
                if(userDetails.get(i)[2].equals("admin")){      // Checking if the user is admin to provide admin rights
                    addItem_btn.setVisible(true);
                    editItem_btn.setVisible(true);
                    deleteItem_btn.setVisible(true);
                    commit_btn.setVisible(true);
                }
                
                mainCardLayout.show(mainContainer, "userCard");
                welcomeUser_lbl.setText("Welcome, "+ userDetails.get(i)[3]);
                
                invalid = false;
                break;
            }
        }
        
        if( invalid ) login_error_message.setText("Please Check Your Credentials !");
        
    }//GEN-LAST:event_login_btnActionPerformed

    private void login_switch_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_login_switch_btnActionPerformed
        clearLoginCardFields();
        registrationCardLayout.show(registrationContainer, "signupCard");
    }//GEN-LAST:event_login_switch_btnActionPerformed

    private void exit_buttonMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_exit_buttonMouseClicked
        System.exit(0);          // Close the application
    }//GEN-LAST:event_exit_buttonMouseClicked

    private void minimize_buttonMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_minimize_buttonMouseClicked
        this.setState(JFrame.ICONIFIED);
    }//GEN-LAST:event_minimize_buttonMouseClicked

    private void signup_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_signup_btnActionPerformed
        String username = signup_username_txtfield.getText().trim();
        String password = new String(signup_password_txtfield.getPassword()).trim();
        String repassword = new String(signup_repassword_txtfield.getPassword()).trim();
        
        
        boolean valid = true;

        for(String[] values: userDetails){
            if (values[0].equals(username)) {valid = false;break;}
        }

        if(valid){
            if(! password.equals(repassword)){
                signup_error_message.setText("Passwords don't match. Try again!");
                
            }else if(password.length()<8){
                signup_error_message.setText("Password needs to have at least 8 characters.");
                
            }else{
                JOptionPane.showConfirmDialog(this, "Account successfully created", "Register", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
                userDetails.add(new String[]{ username, password, "user", username });
                updateUserDirectory();
                clearSignUpCardFields();
            }
            
        }else{
            signup_error_message.setText("Username is in use. Try a new one.");
        }
        
    }//GEN-LAST:event_signup_btnActionPerformed

    private void signup_switch_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_signup_switch_btnActionPerformed
        clearSignUpCardFields();
        registrationCardLayout.show(registrationContainer, "loginCard");
    }//GEN-LAST:event_signup_switch_btnActionPerformed

    private void main_exit_buttonMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_main_exit_buttonMouseClicked
        System.exit(0);          // Close the application
    }//GEN-LAST:event_main_exit_buttonMouseClicked

    private void main_minimize_buttonMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_main_minimize_buttonMouseClicked
        this.setState(JFrame.ICONIFIED);
    }//GEN-LAST:event_main_minimize_buttonMouseClicked

    private void login_password_txtfieldKeyPressed(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_login_password_txtfieldKeyPressed
        if (evt.getKeyCode() == 10)login_btnActionPerformed(null);
    }//GEN-LAST:event_login_password_txtfieldKeyPressed

    private void logout_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_logout_btnActionPerformed
        int choice = JOptionPane.showConfirmDialog(null, "Do you wish to log out?", "Confirmation", JOptionPane.OK_CANCEL_OPTION, JOptionPane.QUESTION_MESSAGE);
        if (choice == JOptionPane.OK_OPTION) {
            userId = -1;
            itemDetails.clear();
            clearSidePanelFields();
            hideAdminButtons();
            itemCardLayout.show(servicesContainer, "tableCard");
            mainCardLayout.show(mainContainer, "navigation");
        }
    }//GEN-LAST:event_logout_btnActionPerformed

    private void commit_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_commit_btnActionPerformed
        try{
            FileWriter csvWriter = new FileWriter(curFilePath);
            for(String[] values : itemDetails){
                csvWriter.append( String.join(",", values)+"\n");
            }
            // Closing writer head
            csvWriter.flush();
            csvWriter.close();
            JOptionPane.showConfirmDialog(this, "Your changes have been saved", "Notification", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
            
        } catch (Exception e) {
          e.printStackTrace();
        }        
    }//GEN-LAST:event_commit_btnActionPerformed

    
    private void editUserProfile_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_editUserProfile_btnActionPerformed
        
        String[] curUserDetails = userDetails.get(userId);
        
        JTextField Name_txtField = new JTextField();
        JTextField Username_txtField = new JTextField();
        JPasswordField Password_txtField = new JPasswordField();
        
        final JComponent[] editProfileForm = new JComponent[] {
            new JLabel("Name : "), Name_txtField, new JLabel(" "),
            new JLabel("Username : "), Username_txtField, new JLabel(" "),
            new JLabel("Password: "), Password_txtField, new JLabel(" ")
        };

        Name_txtField.setText(curUserDetails[3]);
        Username_txtField.setText(curUserDetails[0]);
        Password_txtField.setText(curUserDetails[1]);
        
        int choice = JOptionPane.showConfirmDialog(null, editProfileForm, "Profile Info", JOptionPane.OK_CANCEL_OPTION, JOptionPane.PLAIN_MESSAGE);
        
        if (choice == JOptionPane.OK_OPTION) {
            
            String newName = Name_txtField.getText();
            String newUsername = Username_txtField.getText();
            String newPassword = new String(Password_txtField.getPassword()).trim();
            
            if( newName.isBlank() || newUsername.isBlank() || newPassword.isBlank() || newPassword.length() < 8 ){
                JOptionPane.showMessageDialog(this, "The changes can't be implemented. \nMake sure the fields aren't left blank and \nthe password has at least 8 characters.", "Edit Profile", JOptionPane.ERROR_MESSAGE);
            
            } else {
                userDetails.get(userId)[3] = newName;
                userDetails.get(userId)[0] = newUsername;
                userDetails.get(userId)[1] = newPassword;
                updateUserDirectory();
                welcomeUser_lbl.setText("Welcome, "+ newName);
            }
        }
    }//GEN-LAST:event_editUserProfile_btnActionPerformed

    
    private void sort_chkboxActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_sort_chkboxActionPerformed
        if(sort_chkbox.isSelected()){
            ascending_btn.setEnabled(true);
            descending_btn.setEnabled(true);
            ascending_btn.setSelected(true);
            ascending_btnActionPerformed(null);
        }else{
            sortButtonGroup.clearSelection();
            ascending_btn.setEnabled(false);
            descending_btn.setEnabled(false);
            algo.setSortOrder(-1);
        }
    }//GEN-LAST:event_sort_chkboxActionPerformed

    private void category_chkboxActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_category_chkboxActionPerformed
        if(category_chkbox.isSelected()){
            name_btn.setEnabled(true);
            manufacturer_btn.setEnabled(true);
            material_btn.setEnabled(true);
            type_btn.setEnabled(true);
            price_btn.setEnabled(true);
            name_btn.setSelected(true);
            search_txtfield.setText("");
            name_btnActionPerformed(null);
        }else{
            categoryButtonGroup.clearSelection();
            name_btn.setEnabled(false);
            manufacturer_btn.setEnabled(false);
            material_btn.setEnabled(false);
            type_btn.setEnabled(false);
            price_btn.setEnabled(false);
            algo.setCategory(-1);
        }
    }//GEN-LAST:event_category_chkboxActionPerformed

    private void search_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_search_btnActionPerformed
        searchIndexList.clear();
        
        String searchFor = search_txtfield.getText().trim();
        
        if(searchFor.length()>0){
            if(sort_chkbox.isSelected()){
                
                if(category_chkbox.isSelected()){
                    try {
                        if(algo.getCategory() == 4 ) Integer.parseInt(searchFor);
                        searchIndexList = algo.BinarySearch(searchFor, itemIndex, itemDetails);
                        JOptionPane.showConfirmDialog(this, searchIndexList.size()+" items were found that matched the search criteria.", "Search Result", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
                        updateFrameTable(searchIndexList);
                    } catch (NumberFormatException e) {
                        JOptionPane.showConfirmDialog(this, "Price only consists of digits.", "Invalid Search", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
                    }catch (Exception e){
                        e.printStackTrace();
                    }
                }else{
                    JOptionPane.showConfirmDialog(this, "Category must be Selected", "Sorting Validation", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
                }
            }else{
                 searchIndexList = algo.LinearSearch(searchFor, itemIndex, itemDetails);
                 JOptionPane.showConfirmDialog(this, searchIndexList.size()+" items were found that matched the search criteria.", "Search Result", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
                 updateFrameTable(searchIndexList);
            }
        }else{
            updateFrameTable(itemIndex);
        }
    }//GEN-LAST:event_search_btnActionPerformed

    private void addItem_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_addItem_btnActionPerformed
        itemCardLayout.show(servicesContainer, "itemCard");
        itemClear_btn.setVisible(true);
    }//GEN-LAST:event_addItem_btnActionPerformed

    private void editItem_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_editItem_btnActionPerformed
        if(catalouge.getSelectedRow() == -1){
            JOptionPane.showConfirmDialog(null, "A row has to be selected to be edited.", "Item Info", JOptionPane.DEFAULT_OPTION, JOptionPane.PLAIN_MESSAGE);
        }else{
            
            String[] curItemDetails;
        
            if (catalouge.getRowCount() == itemDetails.size()){     // Handling case where the table is in default
                curItemDetails =  itemDetails.get( itemIndex.get(catalouge.getSelectedRow()) );

            }else{                  // Handling cause where the table is in search mode
                curItemDetails =  itemDetails.get( searchIndexList.get(catalouge.getSelectedRow()) );
            }
            
            // Insert values from table to the fields
            frameName_txtfield.setText(curItemDetails[0]);
            manufacturer_txtfield.setText(curItemDetails[1]);
            material_comboBox.setSelectedItem(curItemDetails[2]);
            type_comboBox.setSelectedItem(curItemDetails[3]);
            color_comboBox.setSelectedItem(curItemDetails[5]);
            price_txtfield.setText(curItemDetails[4]);
            quantity_txtfield.setText(curItemDetails[8]);
            if(curItemDetails[6] == "Unisex"){
                unisex_btn.setSelected(true);
            }else if(curItemDetails[6] == "Male"){
                male_btn.setSelected(true);
            }else{
                female_btn.setSelected(true);
            }
            description_textArea.setText(curItemDetails[7]);
            
            itemCardLayout.show(servicesContainer, "itemCard");
        }
            
    }//GEN-LAST:event_editItem_btnActionPerformed

    private void deleteItem_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_deleteItem_btnActionPerformed
        if(catalouge.getSelectedRow() == -1){
            JOptionPane.showConfirmDialog(null, "A row has to be selected to be deleted.", "Item Info", JOptionPane.DEFAULT_OPTION, JOptionPane.PLAIN_MESSAGE);
        }else{
            int pos;
            if (catalouge.getRowCount() == itemDetails.size()){     // Handling case where the table is in default
                pos = itemIndex.remove(catalouge.getSelectedRow());
                
            }else{                  // Handling cause where the table is in search mode
                pos = searchIndexList.get(catalouge.getSelectedRow());
            }
            
            itemDetails.remove( pos );
            
            // Reset all indexes
            itemIndex.clear();  
            for(int i=0;i<itemDetails.size(); i++){
                itemIndex.add(i);
            }
            clearSidePanelFields();
            updateFrameTable(itemIndex);

        }
    }//GEN-LAST:event_deleteItem_btnActionPerformed

    private void ascending_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_ascending_btnActionPerformed
        algo.setSortOrder(0);
        itemIndex = algo.mergeSort(itemIndex, itemDetails);
        updateFrameTable(itemIndex);
        search_txtfield.setText("");
    }//GEN-LAST:event_ascending_btnActionPerformed

    private void descending_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_descending_btnActionPerformed
        algo.setSortOrder(1);
        itemIndex = algo.mergeSort(itemIndex, itemDetails);
        updateFrameTable(itemIndex);
        search_txtfield.setText("");
    }//GEN-LAST:event_descending_btnActionPerformed

    private void name_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_name_btnActionPerformed
        if(algo.getCategory()!=0){
            algo.setCategory(0);
            if(sort_chkbox.isSelected()){
                itemIndex = algo.mergeSort(itemIndex, itemDetails);
                updateFrameTable(itemIndex);
                search_txtfield.setText("");
            }
        }
    }//GEN-LAST:event_name_btnActionPerformed

    private void manufacturer_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_manufacturer_btnActionPerformed
        if(algo.getCategory()!=1){
            algo.setCategory(1);
            if(sort_chkbox.isSelected()){
                itemIndex = algo.mergeSort(itemIndex, itemDetails);
                updateFrameTable(itemIndex);
                search_txtfield.setText("");
            }
        }
    }//GEN-LAST:event_manufacturer_btnActionPerformed

    private void material_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_material_btnActionPerformed
        if(algo.getCategory()!=2){
            algo.setCategory(2);
            if(sort_chkbox.isSelected()){
                itemIndex = algo.mergeSort(itemIndex, itemDetails);
                updateFrameTable(itemIndex);
                search_txtfield.setText("");
            }
        }
    }//GEN-LAST:event_material_btnActionPerformed

    private void type_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_type_btnActionPerformed
        if(algo.getCategory()!=3){
            algo.setCategory(3);
            if(sort_chkbox.isSelected()){
                itemIndex = algo.mergeSort(itemIndex, itemDetails);
                updateFrameTable(itemIndex);
                search_txtfield.setText("");
            }
        }
    }//GEN-LAST:event_type_btnActionPerformed

    private void price_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_price_btnActionPerformed
        if(algo.getCategory()!=4){
            algo.setCategory(4);
            if(sort_chkbox.isSelected()){
                itemIndex = algo.mergeSort(itemIndex, itemDetails);
                updateFrameTable(itemIndex);
                search_txtfield.setText("");
            }
        }
    }//GEN-LAST:event_price_btnActionPerformed

    private void search_txtfieldKeyPressed(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_search_txtfieldKeyPressed
        if (evt.getKeyCode() == 10) search_btnActionPerformed(null);
    }//GEN-LAST:event_search_txtfieldKeyPressed

    private void mainContainerMousePressed(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_mainContainerMousePressed
        mouseCord_x = evt.getX();       // Pre-set the starting x co-ordinate of the mouse
        mouseCord_y = evt.getY();       // Pre-set the starting y co-ordinate of the mouse
    }//GEN-LAST:event_mainContainerMousePressed

    
    private void mainContainerMouseDragged(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_mainContainerMouseDragged
        // Drag the panel to the location of the mouse while dragging
        int x = evt.getXOnScreen() - this.mouseCord_x;
        int y = evt.getYOnScreen() - this.mouseCord_y;
        this.setLocation(x,y);          // Update the panel to a new position
    }//GEN-LAST:event_mainContainerMouseDragged

    private void itemClear_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_itemClear_btnActionPerformed
        // Reset all values to empty
        frameName_txtfield.setText("");
        manufacturer_txtfield.setText("");
        material_comboBox.setSelectedIndex(0);
        type_comboBox.setSelectedIndex(0);
        color_comboBox.setSelectedIndex(0);
        price_txtfield.setText("");
        quantity_txtfield.setText("");
        genderButtonGroup.clearSelection();
        description_textArea.setText("");
        
    }//GEN-LAST:event_itemClear_btnActionPerformed

    private void itemCancel_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_itemCancel_btnActionPerformed
        itemClear_btnActionPerformed(null);
        itemClear_btn.setVisible(false);
        itemCardLayout.show(servicesContainer, "tableCard");
    }//GEN-LAST:event_itemCancel_btnActionPerformed

    private void itemSave_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_itemSave_btnActionPerformed
        
        String[] values = getItemsFromUser();
        if(values.length!=0){
            if(itemClear_btn.isVisible()){      // Adding a new field if the panel is in add mode
                itemDetails.add(values);    
                itemIndex.add(itemDetails.size()-1);
                JOptionPane.showConfirmDialog(this, "The new item has been added to the system.", "Notification", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
                
            }else{                              // Updating the previous field if the panel is in edit mode
                int pos;
                if (catalouge.getRowCount() == itemDetails.size()){     // Handling case where the table is in default
                    pos = itemIndex.get(catalouge.getSelectedRow());

                }else{                  // Handling cause where the table is in search mode
                    pos = searchIndexList.get(catalouge.getSelectedRow());
                }
                itemDetails.set(pos, values);
                JOptionPane.showConfirmDialog(this, "The item has been updated in the system.", "Notification", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
            }
            
            clearSidePanelFields();
            updateFrameTable(itemIndex);
            itemCancel_btnActionPerformed(null);
        }
        
    }//GEN-LAST:event_itemSave_btnActionPerformed

    private void backToMain_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_backToMain_btnActionPerformed
        search_btn.setEnabled(true);
        search_txtfield.setEnabled(true);
        category_chkbox.setEnabled(true);
        sort_chkbox.setEnabled(true);
        addItem_btn.setEnabled(true);
        editItem_btn.setEnabled(true);
        deleteItem_btn.setEnabled(true);
        commit_btn.setEnabled(true);
        
        itemCardLayout.show(servicesContainer, "tableCard");
    }//GEN-LAST:event_backToMain_btnActionPerformed

    private void footer_lblMousePressed(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_footer_lblMousePressed
        itemClear_btnActionPerformed(null);
        itemClear_btn.setVisible(false);
        clearSidePanelFields();
        
        search_btn.setEnabled(false);
        search_txtfield.setEnabled(false);
        category_chkbox.setEnabled(false);
        sort_chkbox.setEnabled(false);
        addItem_btn.setEnabled(false);
        editItem_btn.setEnabled(false);
        deleteItem_btn.setEnabled(false);
        commit_btn.setEnabled(false);
        
        itemCardLayout.show(servicesContainer, "aboutUsCard");
    }//GEN-LAST:event_footer_lblMousePressed

       
    
    
    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new MainFrame().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JPanel aboutUsPanel;
    private javax.swing.JLabel aboutUs_description_lbl;
    private javax.swing.JButton addItem_btn;
    private javax.swing.JRadioButton ascending_btn;
    private javax.swing.JButton backToMain_btn;
    private javax.swing.JScrollPane catalogueScroller;
    private javax.swing.JTable catalouge;
    private javax.swing.ButtonGroup categoryButtonGroup;
    private javax.swing.JCheckBox category_chkbox;
    private javax.swing.JComboBox<String> color_comboBox;
    private javax.swing.JLabel color_lbl;
    private javax.swing.JButton commit_btn;
    private javax.swing.JLabel copyright_lbl;
    private javax.swing.JButton deleteItem_btn;
    private javax.swing.JRadioButton descending_btn;
    private javax.swing.JLabel description_lbl;
    private javax.swing.JTextArea description_textArea;
    private javax.swing.JButton editItem_btn;
    private javax.swing.JButton editUserProfile_btn;
    private javax.swing.JLabel exit_button;
    private javax.swing.JRadioButton female_btn;
    private javax.swing.JLabel filters_lbl;
    private javax.swing.JLabel footer_lbl;
    private javax.swing.JLabel frameName_lbl;
    private javax.swing.JTextField frameName_txtfield;
    private javax.swing.ButtonGroup genderButtonGroup;
    private javax.swing.JLabel gender_lbl;
    private javax.swing.JButton itemCancel_btn;
    private javax.swing.JButton itemClear_btn;
    private javax.swing.JPanel itemPannel;
    private javax.swing.JButton itemSave_btn;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JPanel loginCard;
    private javax.swing.JButton login_btn;
    private javax.swing.JLabel login_error_message;
    private javax.swing.JLabel login_image;
    private javax.swing.JLabel login_password_lbl;
    private javax.swing.JPasswordField login_password_txtfield;
    private javax.swing.JButton login_switch_btn;
    private javax.swing.JLabel login_title;
    private javax.swing.JLabel login_username_lbl;
    private javax.swing.JTextField login_username_txtfield;
    private javax.swing.JButton logout_btn;
    private javax.swing.JPanel mainContainer;
    private javax.swing.JLabel main_exit_button;
    private javax.swing.JLabel main_minimize_button;
    private javax.swing.JRadioButton male_btn;
    private javax.swing.JRadioButton manufacturer_btn;
    private javax.swing.JLabel manufacturer_lbl;
    private javax.swing.JTextField manufacturer_txtfield;
    private javax.swing.JRadioButton material_btn;
    private javax.swing.JComboBox<String> material_comboBox;
    private javax.swing.JLabel material_lbl;
    private javax.swing.JLabel minimize_button;
    private javax.swing.JRadioButton name_btn;
    private javax.swing.JPanel navigation_UI;
    private javax.swing.JLabel opticalog_icon;
    private javax.swing.JRadioButton price_btn;
    private javax.swing.JLabel price_lbl;
    private javax.swing.JTextField price_txtfield;
    private javax.swing.JLabel quantity_lbl;
    private javax.swing.JTextField quantity_txtfield;
    private javax.swing.JPanel registrationContainer;
    private javax.swing.JButton search_btn;
    private javax.swing.JTextField search_txtfield;
    private javax.swing.JPanel servicesContainer;
    private javax.swing.JPanel sidePanel;
    private javax.swing.JPanel signupCard;
    private javax.swing.JButton signup_btn;
    private javax.swing.JLabel signup_error_message;
    private javax.swing.JLabel signup_password_lbl;
    private javax.swing.JPasswordField signup_password_txtfield;
    private javax.swing.JLabel signup_repassword_lbl;
    private javax.swing.JPasswordField signup_repassword_txtfield;
    private javax.swing.JButton signup_switch_btn;
    private javax.swing.JLabel signup_title;
    private javax.swing.JLabel signup_username_lbl;
    private javax.swing.JTextField signup_username_txtfield;
    private javax.swing.ButtonGroup sortButtonGroup;
    private javax.swing.JCheckBox sort_chkbox;
    private javax.swing.JPanel tableContainer;
    private javax.swing.JRadioButton type_btn;
    private javax.swing.JComboBox<String> type_comboBox;
    private javax.swing.JLabel type_lbl;
    private javax.swing.JRadioButton unisex_btn;
    private javax.swing.JLabel user_icon;
    private javax.swing.JPanel user_panel;
    private javax.swing.JLabel welcomeUser_lbl;
    // End of variables declaration//GEN-END:variables

    
    
    /**
     * Adds menu bar to the title bar
     */
    private void addMenuBar(){
        
        JMenuBar menubar = new JMenuBar();
        JMenu fileMenu = new JMenu("File");
        JMenu toolsMenu = new JMenu("Tool");
        JMenu helpMenu = new JMenu("Help");
        
        JMenuItem openMenu = new JMenuItem(new AbstractAction("Open") {
            
            @Override
            public void actionPerformed(ActionEvent evt) {
                JFileChooser choice = new JFileChooser();
                FileNameExtensionFilter filter = new FileNameExtensionFilter("*.csv", "csv");       // Set file filter to only csv files
                choice.setFileFilter(filter);
                
                if( choice.showOpenDialog(null) == JFileChooser.APPROVE_OPTION) {           // Handle when the user approves the file import
                    curFilePath = choice.getSelectedFile().getAbsolutePath();
                    loadItemDetails();
                }
            }
            
        });
        
        
        JMenuItem exitMenu = new JMenuItem(new AbstractAction("Exit") {
            
            @Override
            public void actionPerformed(ActionEvent evt) {
                exit_buttonMouseClicked(null);
            }
            
        });
        
        
                
        JMenuItem helpAppMenu = new JMenuItem(new AbstractAction("FAQ"){
            
            @Override
            public void actionPerformed(ActionEvent evt) {
                // Open a custom generated help.pdf file when the item is pressed
                if (Desktop.isDesktopSupported()) {
                    try {
                        File helpFile = new File(helpPDFPath);
                        Desktop.getDesktop().open(helpFile);    // Open the file in default pdf viewer for the desktop
                        
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            }
        });
        
        JMenuItem aboutAppMenu = new JMenuItem(new AbstractAction("About app") {
            
            @Override
            public void actionPerformed(ActionEvent evt) {
                footer_lblMousePressed(null);
            }
            
        });
        
        
        JMenuItem resetMenu = new JMenuItem(new AbstractAction("Reset Table"){
            
            @Override
            public void actionPerformed(ActionEvent e) {
                curFilePath = catalogueDirectoryPath;
                loadItemDetails();          // Reset the table to default values from the main database
                clearSidePanelFields();
            }
            
        }); 
        
        // Addition of JMenuItems in respective JMenu
        fileMenu.add(openMenu);
        fileMenu.add(exitMenu);
        toolsMenu.add(resetMenu);
        helpMenu.add(helpAppMenu);
        helpMenu.add(aboutAppMenu);
        menubar.add(fileMenu);
        menubar.add(toolsMenu);
        menubar.add(helpMenu);
        
        // Customization for menu
        fileMenu.setBorderPainted(false);
        toolsMenu.setBorderPainted(false);
        helpMenu.setBorderPainted(false);
        openMenu.setBorderPainted(false);
        exitMenu.setBorderPainted(false);
        resetMenu.setBorderPainted(false);
        helpAppMenu.setBorderPainted(false);
        aboutAppMenu.setBorderPainted(false);
        menubar.setBorderPainted(false);
        menubar.setForeground(CustomFadedWhite);
        sidePanel.add(menubar , new org.netbeans.lib.awtextra.AbsoluteConstraints(30, 30, -1, -1));
    }
    
    
    
    /**
     * Customization for some specific components
     */
    private void addCustomization(){
        
        // Customization to specific components
        login_title.setFont(bauhaus);
        login_error_message.setFont(comforta);
        login_switch_btn.setFont(comforta);
        signup_title.setFont(bauhaus);
        signup_error_message.setFont(comforta);
        signup_switch_btn.setFont(comforta);
        copyright_lbl.setFont(courier);
        welcomeUser_lbl.setFont(caviar.deriveFont(Font.BOLD,20));
        
        // Customization of main table
        catalouge.getTableHeader().setFont(caviar.deriveFont(Font.BOLD,14));
        catalouge.getTableHeader().setBorder(BorderFactory.createLineBorder(CustomSkyBlue));
        catalouge.getTableHeader().setForeground(CustomFadedWhite);  
        catalouge.getTableHeader().setBackground(CustomSkyBlue);
        catalogueScroller.getVerticalScrollBar().setBackground(CustomFadedWhite);
        catalogueScroller.getVerticalScrollBar().setUI(new BasicScrollBarUI() {
            @Override
            protected void configureScrollBarColors() {
                this.thumbColor = CustomFadedBlack;
            }
        });
        catalouge.getColumnModel().getColumn(0).setPreferredWidth(100);
        catalouge.getColumnModel().getColumn(3).setPreferredWidth(20);
        catalouge.getColumnModel().getColumn(4).setPreferredWidth(20);
        
        
        // Allowing pop up with item details from table
        catalouge.addMouseListener(new MouseAdapter() {     

            public void mouseClicked (MouseEvent mEvnt) {
                if (mEvnt.getClickCount() == 2) {       // Check for double mouse click
                    displayItemDetails();
                }
            }
        });
        
    }
    
    
    
    /**
     * Import User Details from database
     */
    private void loadUserDetails(){
        try{
            BufferedReader br = new BufferedReader(new FileReader(userDirectoryPath));
            String line = "";
            while ( (line = br.readLine()) != null) {
                userDetails.add(line.split(","));
            }
            br.close();
        } catch (Exception e) {
          e.printStackTrace();
        }
    }
    
    
    
    /**
     * Store the updated details into the database
     */
    private void updateUserDirectory(){
        try{
            FileWriter csvWriter = new FileWriter(userDirectoryPath);
            for(String[] values : userDetails){
                csvWriter.append( String.join(",", values)+"\n");
            }
            // Closing writer head
            csvWriter.flush();
            csvWriter.close();
            
        } catch (Exception e) {
          e.printStackTrace();
        }
    }
    
    
    
    /**
     * Import Item Details from database
     */
    private void loadItemDetails(){
        // Empty all list for new values
        itemIndex.clear();
        itemDetails.clear();
        searchIndexList.clear();
        
        try{
            BufferedReader br = new BufferedReader(new FileReader(curFilePath));        // Import data from the current file path
            String line = "";
            int counter = 0;
            while ( (line = br.readLine()) != null) {
                itemIndex.add(counter);
                itemDetails.add(line.split(","));       // Spliting a line of values in order to otain a row of values
                counter++;
            }
            br.close();
            updateFrameTable(itemIndex);
            
        } catch (Exception e) {
          e.printStackTrace();
        }
    }
    
    
    
    /**
     * Updates the elements inside the table with the current set of values
     */
    private void updateFrameTable(List<Integer> indexes){
        
        DefaultTableModel catalogueTable = (DefaultTableModel) catalouge.getModel();
        catalogueTable.getDataVector().removeAllElements();     // Clear the current table
        catalogueTable.fireTableDataChanged();
        catalogueTable.setRowCount(indexes.size());             // Update the table row count to the list size
        
        int curIndex = 0;
        for(int pos: indexes){
            for (int i = 0; i < 5; i++) {
                catalogueTable.setValueAt(itemDetails.get(pos)[i], curIndex, i);          // Add data for each specific row of specific column                    
            }
            curIndex++;
        }
    }
    
    
    
    private void displayItemDetails(){
        
        String[] curItemDetails;
        
        if (catalouge.getRowCount() == itemDetails.size()){     // Handling case where the table is in default
            curItemDetails =  itemDetails.get( itemIndex.get(catalouge.getSelectedRow()) );
            
        }else{                  // Handling cause where the table is in search mode
            curItemDetails =  itemDetails.get( searchIndexList.get(catalouge.getSelectedRow()) );
        }
        
        // Initializing components
        JTextField curFrameName_txtField = new JTextField();
        JTextField curManufacturer_txtField = new JTextField();
        JTextField curMaterial_txtField = new JTextField();
        JTextField curFrameType_txtField = new JTextField();
        JTextField curPrice_txtField = new JTextField();
        JTextField curColor_txtField = new JTextField();
        JTextField curGender_txtField = new JTextField();
        JTextArea curDescription_txtField = new JTextArea();
        JTextField curQuantity_txtField = new JTextField();

        final JComponent[] viewItemDetailForm = new JComponent[] {
            new JLabel("Frame Name : "), curFrameName_txtField, new JLabel(" "),
            new JLabel("Manufacturer : "), curManufacturer_txtField, new JLabel(" "),
            new JLabel("Material : "), curMaterial_txtField, new JLabel(" "),
            new JLabel("Type : "), curFrameType_txtField, new JLabel(" "),
            new JLabel("Price : "), curPrice_txtField, new JLabel(" "),
            new JLabel("Color : "), curColor_txtField, new JLabel(" "),
            new JLabel("Gender : "), curGender_txtField, new JLabel(" "),
            new JLabel("Description : "), curDescription_txtField, new JLabel(" "),
            new JLabel("Quantity : "), curQuantity_txtField, new JLabel(" "),
            
        };

        // Adding value to each field
        curFrameName_txtField.setText(curItemDetails[0]);
        curManufacturer_txtField.setText(curItemDetails[1]);
        curMaterial_txtField.setText(curItemDetails[2]);
        curFrameType_txtField.setText(curItemDetails[3]);
        curPrice_txtField.setText(curItemDetails[4]);
        curColor_txtField.setText(curItemDetails[5]);
        curGender_txtField.setText(curItemDetails[6]);
        curDescription_txtField.setText(curItemDetails[7]);
        curQuantity_txtField.setText(curItemDetails[8]);
        
        // Ensuring each field is uneditable
        curFrameName_txtField.setEditable(false);
        curManufacturer_txtField.setEditable(false);
        curMaterial_txtField.setEditable(false);
        curFrameType_txtField.setEditable(false);
        curPrice_txtField.setEditable(false);
        curColor_txtField.setEditable(false);
        curGender_txtField.setEditable(false);
        curDescription_txtField.setEditable(false);
        curQuantity_txtField.setEditable(false);

        JOptionPane.showConfirmDialog(null, viewItemDetailForm, "Item Info", JOptionPane.DEFAULT_OPTION, JOptionPane.PLAIN_MESSAGE);
    }
    
    
    private String[] getItemsFromUser(){
        
        String[] values = new String[9];
        
        // Obtain Frame Name
        values[0] = frameName_txtfield.getText().trim();    
        if(values[0].isBlank()){        // Validation check
            JOptionPane.showConfirmDialog(this, "Frame Name TextField can't be left empty", "Inpur Error", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
            return new String[0];       // Passing empty value as validation checker
        }
        
        // Obtain manufacturer
        values[1] = manufacturer_txtfield.getText().trim();
        if(values[1].isBlank()){        // Validation check
            JOptionPane.showConfirmDialog(this, "Manufacturer TextField can't be left empty", "Inpur Error", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
            return new String[0];       // Passing empty value as validation checker
        }
        
        // Obtain material
        values[2] =  String.valueOf(material_comboBox.getSelectedItem()).trim();
        if(material_comboBox.getSelectedIndex() == 0){        // Validation check
            JOptionPane.showConfirmDialog(this, "Material has to be selected", "Inpur Error", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
            return new String[0];       // Passing empty value as validation checker
        }
        
        // Obtain type
        values[3] =  String.valueOf(type_comboBox.getSelectedItem()).trim();
        if(type_comboBox.getSelectedIndex() == 0){        // Validation check
            JOptionPane.showConfirmDialog(this, "Frame Type has to be selected", "Inpur Error", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
            return new String[0];       // Passing empty value as validation checker
        }
        
        // Obtain color
        values[5] =  String.valueOf(color_comboBox.getSelectedItem()).trim();
        if(color_comboBox.getSelectedIndex() == 0){        // Validation check
            JOptionPane.showConfirmDialog(this, "Frame Color has to be selected", "Inpur Error", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
            return new String[0];       // Passing empty value as validation checker
        }
        
        
        // Obtain price
        values[4] = price_txtfield.getText().trim();
        if(values[4].isBlank() || isNotDigit(values[4])){        // Validation check
            JOptionPane.showConfirmDialog(this, "Price TextField must be only integers and not blank.", "Inpur Error", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
            return new String[0];       // Passing empty value as validation checker
        }
        
        // Obtain quanity
        values[8] = quantity_txtfield.getText().trim();
        if(values[8].isBlank() || isNotDigit(values[8])){        // Validation check
            JOptionPane.showConfirmDialog(this, "Quantity TextField must be only integers and not blank.", "Inpur Error", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
            return new String[0];       // Passing empty value as validation checker
        }
        
        
        // Obtain gender
        try{
            values[6] = genderButtonGroup.getSelection().getActionCommand();
        }catch(Exception e){
            JOptionPane.showConfirmDialog(this, "Gender must be selected.", "Inpur Error", JOptionPane.DEFAULT_OPTION, JOptionPane.INFORMATION_MESSAGE);
            return new String[0];       // Passing empty value as validation checker
        }
        
        // Obtain Description
        values[7] = description_textArea.getText().trim();
                
        return values;
    }    
    
    
    
    private boolean isNotDigit(String val){
        try{
            Integer.parseInt(val);
            return false;
        }catch(Exception e){
            return true;
        }
    }
    
    
    // Clear all the values and set the components in login card to empty
    private void clearLoginCardFields(){
        login_username_txtfield.setText("");
        login_password_txtfield.setText("");
        login_error_message.setText("");
    }                                       

    // Clear all the values and set the components in sign up card to empty
    private void clearSignUpCardFields(){
        signup_username_txtfield.setText("");
        signup_password_txtfield.setText("");
        signup_repassword_txtfield.setText("");
        signup_error_message.setText("");
    }

    // Clear all the values and set the components in side panel to empty
    private void clearSidePanelFields(){
        search_txtfield.setText("");
        sortButtonGroup.clearSelection();
        categoryButtonGroup.clearSelection();
        
        ascending_btn.setEnabled(false);
        descending_btn.setEnabled(false);
        name_btn.setEnabled(false);
        manufacturer_btn.setEnabled(false);
        material_btn.setEnabled(false);
        type_btn.setEnabled(false);
        price_btn.setEnabled(false);
        
        sort_chkbox.setSelected(false);
        category_chkbox.setSelected(false);
    }
    
    // Hides the services that are only accessible by admin
    private void hideAdminButtons(){
        addItem_btn.setVisible(false);
        editItem_btn.setVisible(false);
        deleteItem_btn.setVisible(false);
        commit_btn.setVisible(false);
    }
    
}
