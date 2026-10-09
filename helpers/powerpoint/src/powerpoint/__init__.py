import uuid

from pptx import Presentation
from pptx.dml.color import RGBColor
from pptx.enum.shapes import MSO_SHAPE
from pptx.enum.text import PP_PARAGRAPH_ALIGNMENT
from pptx.slide import Slide
from pptx.util import Inches, Pt


def STRING(text) -> str:
    from textwrap import dedent
    return dedent(text).strip()


class UniFlowDeck:
    ETUDE_PREALABLE: str = "Étude préalable"
    ANALYSE : str= "Analyse des besoins"
    def applybluetheme(self):
        # Theme Colors
        self.BG_DARK: RGBColor = RGBColor(0x0f, 0x17, 0x2a)  # 0F172A
        self.BG_LIGHT: RGBColor = RGBColor(
            245, 244, 240)       # Off-white / Cream
        self.ACCENT_BLUE: RGBColor = RGBColor(
            37, 99, 235)      # Primary Accent
        self.TEXT_WHITE: RGBColor = RGBColor(255, 255, 255)
        self.TEXT_DARK: RGBColor = RGBColor(17, 24, 39)
        self.TEXT_MUTED_LIGHT: RGBColor = RGBColor(148, 163, 184)
        self.TEXT_MUTED_DARK: RGBColor = RGBColor(100, 116, 139)
        self.TEXT_SUBTITLE_DARK: RGBColor = RGBColor(71, 85, 105)
        self.DIVIDER_GRAY: RGBColor = RGBColor(226, 232, 240)
        self.CARD_WHITE: RGBColor = RGBColor(255, 255, 255)

    def applyredtheme(self):
        # Theme Colors
        self.BG_DARK: RGBColor = RGBColor(0x2f, 0x00, 0x00)  # 0F172A
        self.BG_LIGHT: RGBColor = RGBColor(
            245, 244, 240)       # Off-white / Cream
        self.ACCENT_BLUE: RGBColor = RGBColor(235, 0, 37)      # Primary Accent
        self.TEXT_WHITE: RGBColor = RGBColor(255, 255, 255)
        self.TEXT_DARK: RGBColor = RGBColor(39, 24, 17)
        self.TEXT_MUTED_LIGHT: RGBColor = RGBColor(148, 163, 184)
        self.TEXT_MUTED_DARK: RGBColor = RGBColor(100, 116, 139)
        self.TEXT_SUBTITLE_DARK: RGBColor = RGBColor(71, 85, 105)
        self.DIVIDER_GRAY: RGBColor = RGBColor(226, 232, 240)
        self.CARD_WHITE: RGBColor = RGBColor(255, 255, 255)

    def __init__(self, filename: str = f"{uuid.uuid4()}.pptx"):
        # Typography
        self.FONT_MONO: str = "JetBrains Mono"
        self.FONT_BODY: str = "JetBrains Mono"
        self.applyredtheme()

        self.filename: str = filename
        self.prs = Presentation()
        self.prs.slide_width = Inches(13.333)
        self.prs.slide_height = Inches(7.5)
        self.blank_layout = self.prs.slide_layouts[6]

    def save(self):
        """Saves all added slides into a single PowerPoint file."""
        self.prs.save(self.filename)
        print(f"Presentation saved successfully t '{self.filename}'")

    def _create_slide(self, bg_color: RGBColor):
        """Helper to create a slide with a custom background color."""
        slide = self.prs.slides.add_slide(self.blank_layout)
        background = slide.background
        fill = background.fill
        fill.solid()
        fill.fore_color.rgb = bg_color
        return slide

    def add_title_slide(self):
        """Slide 1: Title / Cover Slide (Dark Theme)"""
        slide = self._create_slide(self.BG_DARK)

        # Header Category Tag
        header_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(0.8), Inches(11.5), Inches(0.4))
        tf_h = header_box.text_frame
        p_h = tf_h.paragraphs[0]
        p_h.text = "PROJET DE FIN D'ÉTUDES — SOUTENANCE"
        p_h.font.name = self.FONT_MONO
        p_h.font.size = Pt(13)
        p_h.font.color.rgb = self.TEXT_MUTED_LIGHT

        # Blue Accent Line
        bar = slide.shapes.add_shape(MSO_SHAPE.RECTANGLE, Inches(
            0.8), Inches(1.4), Inches(1.2), Inches(0.05))
        bar.fill.solid()
        bar.fill.fore_color.rgb = self.ACCENT_BLUE
        bar.line.fill.background()

        # Title
        title_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.8), Inches(11.5), Inches(2.2))
        tf_t = title_box.text_frame
        tf_t.word_wrap = True
        p_t = tf_t.paragraphs[0]
        p_t.text = "Conception et réalisation d'un module CRM pour la plateforme UniFlow-Suite"
        p_t.font.name = self.FONT_BODY
        p_t.font.bold = True
        p_t.font.size = Pt(36)
        p_t.font.color.rgb = self.TEXT_WHITE

        # Subtitle
        sub_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(4.2), Inches(11.0), Inches(1.0))
        tf_s = sub_box.text_frame
        tf_s.word_wrap = True
        p_s = tf_s.paragraphs[0]
        p_s.text = "Une solution SaaS de gestion de la relation client, hébergée en Algérie et intégrée à l'écosystème logiciel d'ITComp"
        p_s.font.name = self.FONT_BODY
        p_s.font.size = Pt(18)
        p_s.font.color.rgb = self.TEXT_MUTED_LIGHT

        # Metadata Grid
        cols = [
            ("Présenté par:", "Aimen Sassi"),
            ("Encadreur:", "Mr Farouk Belhoucine"),
            ("Promotrice:", "Mme Faiza Allaoua"),
            ("Organisme d'accueil:", "ITComp"),
            ("Année:", "2026"),
        ]
        col_width, gap, top_pos = Inches(2.5), Inches(0.1), Inches(5.6)
        for i, (label, val) in enumerate(cols):
            box = slide.shapes.add_textbox(
                Inches(0.8) + i * (col_width + gap), top_pos, col_width, Inches(1.2))
            tf_m = box.text_frame
            tf_m.word_wrap = True

            p_l = tf_m.paragraphs[0]
            p_l.text = label
            p_l.font.name = self.FONT_MONO
            p_l.font.size = Pt(11)
            p_l.font.color.rgb = self.TEXT_MUTED_LIGHT
            p_l.space_after = Pt(4)

            p_v = tf_m.add_paragraph()
            p_v.text = val
            p_v.font.name = self.FONT_MONO
            p_v.font.size = Pt(12)
            p_v.font.color.rgb = self.TEXT_WHITE

    def add_plan_slide(self):
        """Slide 2: Plan de la présentation / Sommaire (Light Theme)"""
        slide = self._create_slide(self.BG_LIGHT)

        # Top Category Tag
        tag_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(0.7), Inches(11.5), Inches(0.4))
        p_tag = tag_box.text_frame.paragraphs[0]
        p_tag.text = "SOMMAIRE"
        p_tag.font.name = self.FONT_MONO
        p_tag.font.size = Pt(13)
        p_tag.font.color.rgb = self.ACCENT_BLUE
        p_tag.font.bold = True

        # Main Title
        title_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.1), Inches(11.5), Inches(0.8))
        p_title = title_box.text_frame.paragraphs[0]
        p_title.text = "Plan de la présentation"
        p_title.font.name = self.FONT_BODY
        p_title.font.bold = True
        p_title.font.size = Pt(36)
        p_title.font.color.rgb = self.TEXT_DARK

        # Grid Content Data
        grid_items = [
            ("01", "Étude préalable", "Contexte, problématique, objectifs, périmètre", Inches(
                0.8), Inches(2.3)),
            ("02", "Analyse des besoins",
             "Méthodologie UP, acteurs, processus métier", Inches(6.8), Inches(2.3)),
            ("03", "Conception", "Dictionnaire de données, modèle du domaine",
             Inches(0.8), Inches(3.8)),
            ("04", "Réalisation", "Architecture, implémentation, application livrée", Inches(
                6.8), Inches(3.8)),
        ]

        for num, title, desc, left, top in grid_items:
            box = slide.shapes.add_textbox(left, top, Inches(5.6), Inches(1.2))
            tf = box.text_frame
            tf.word_wrap = True
            tf.margin_left = Inches(0)
            tf.margin_right = Inches(0)
            tf.margin_top = Inches(5)
            tf.margin_bottom = Inches(5)

            # Title Row: Number + Section Title
            p_t = tf.paragraphs[0]

            run_num = p_t.add_run()
            run_num.text = f"{num}  "
            run_num.font.name = self.FONT_MONO
            run_num.font.bold = True
            run_num.font.size = Pt(20)
            run_num.font.color.rgb = self.ACCENT_BLUE

            run_title = p_t.add_run()
            run_title.text = title
            run_title.font.name = self.FONT_BODY
            run_title.font.bold = True
            run_title.font.size = Pt(22)
            run_title.font.color.rgb = self.TEXT_DARK
            p_t.space_after = Pt(4)

            # Subtitle Description Row
            p_d = tf.add_paragraph()
            p_d.text = desc
            p_d.font.name = self.FONT_BODY
            p_d.font.size = Pt(13)
            p_d.font.color.rgb = self.TEXT_MUTED_DARK

        # Horizontal Divider Lines under Row 1
        for left in [Inches(0.8), Inches(6.8)]:
            line = slide.shapes.add_shape(
                MSO_SHAPE.RECTANGLE, left, Inches(3.45), Inches(5.6), Inches(0.01))
            line.fill.solid()
            line.fill.fore_color.rgb = self.DIVIDER_GRAY
            line.line.fill.background()

    def _add_top_tag(self, slide, text):
        tag_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(0.7), Inches(11.5), Inches(0.4))
        p_tag = tag_box.text_frame.paragraphs[0]
        p_tag.text = text
        p_tag.font.name = self.FONT_MONO
        p_tag.font.size = Pt(13)
        p_tag.font.color.rgb = self.ACCENT_BLUE
        p_tag.font.bold = True
        return slide

    def _add_title(self, slide, text):
        title_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.1), Inches(11.5), Inches(0.8))
        p_title = title_box.text_frame.paragraphs[0]
        p_title.text = text
        p_title.font.name = self.FONT_BODY
        p_title.font.bold = True
        p_title.font.size = Pt(36)
        p_title.font.color.rgb = self.TEXT_DARK
        return slide

    def _add_paragraph(self, slide, text):
        val_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(2), Inches(12), Inches(1.6))
        tf_val = val_box.text_frame
        tf_val.word_wrap = True
        tf_val.margin_left = tf_val.margin_top = tf_val.margin_right = tf_val.margin_bottom = 0
        p_val = tf_val.paragraphs[0]
        p_val.text = text
        p_val.font.name = self.FONT_BODY
        p_val.font.size = Pt(22)
        p_val.font.color.rgb = self.TEXT_DARK
        return slide

    def add_generic_slide(self, tag: str, title: str, paragraph: str):
        slide = self._create_slide(self.BG_LIGHT)
        slide = self._add_top_tag(slide, tag)
        slide = self._add_title(slide, title)
        slide = self._add_paragraph(slide, paragraph)

    def add_organisme_slide2(self):
        """Slide 3: L'organisme d'accueil (Light Theme)"""
        slide = self._create_slide(self.BG_LIGHT)

        # Top Tag
        tag_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(0.7), Inches(11.5), Inches(0.4))
        p_tag = tag_box.text_frame.paragraphs[0]
        p_tag.text = "ÉTUDE PRÉALABLE"
        p_tag.font.name = self.FONT_MONO
        p_tag.font.size = Pt(13)
        p_tag.font.color.rgb = self.ACCENT_BLUE
        p_tag.font.bold = True

        # Slide Title
        title_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.1), Inches(11.5), Inches(0.8))
        p_title = title_box.text_frame.paragraphs[0]
        p_title.text = "Nos Services"
        p_title.font.name = self.FONT_BODY
        p_title.font.bold = True
        p_title.font.size = Pt(36)
        p_title.font.color.rgb = self.TEXT_DARK

        # 5 Columns Data
        cols_data = [
            ("01", "Conseils"),
            ("02", "Formations"),
            ("03", "Assistance Technique"),
            ("04", "Développement et Integration")
        ]

        col_width = Inches(2.15)
        col_gap = Inches(0.24)
        left_margin = Inches(0.8)
        top_pos = Inches(3.1)

        for i, (num, text) in enumerate(cols_data):
            col_left = left_margin + i * (col_width + col_gap)

            # Top Blue Line
            line = slide.shapes.add_shape(
                MSO_SHAPE.RECTANGLE, col_left, top_pos, col_width, Inches(0.02))
            line.fill.solid()
            line.fill.fore_color.rgb = self.ACCENT_BLUE
            line.line.fill.background()

            # Text box for Column Number & Body
            box = slide.shapes.add_textbox(
                col_left, top_pos + Inches(0.15), col_width, Inches(1.8))
            tf = box.text_frame
            tf.word_wrap = True
            tf.margin_left = tf.margin_right = tf.margin_top = tf.margin_bottom = 0

            p_num = tf.paragraphs[0]
            p_num.text = num
            p_num.font.name = self.FONT_MONO
            p_num.font.size = Pt(12)
            p_num.font.color.rgb = self.TEXT_MUTED_DARK
            p_num.space_after = Pt(6)

            p_txt = tf.add_paragraph()
            p_txt.text = text
            p_txt.font.name = self.FONT_BODY
            p_txt.font.size = Pt(12.5)
            p_txt.font.color.rgb = self.TEXT_DARK

    def add_organisme_slide(self):
        """what we do"""
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide, self.ETUDE_PREALABLE)
        self._add_title(slide, "Presentation d'ITComp")
        ITCOMP_DESC = STRING("""
        ITComp est une Entreprise de Services du Numérique (ESN) algérienne,
        créée en 2003 après avoir débuté comme centre de formation en 1999.
        Elle accompagne les organisations dans leur numérisation.
        Elle est aussi partenaire de grandes entreprises comme Microsoft et Oracle.
        """)
        self._add_paragraph(slide, ITCOMP_DESC)

    def add_uniflow_slide(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide, self.ETUDE_PREALABLE)
        self._add_title(slide, "UniFlow suite")
        self._add_paragraph(slide, STRING("""
        Uniflow-Suite est une solution numérique de gestion scolaire qui centralise les activités académiques et administratives des établissements d’enseignement grâce à plusieurs applications, notamment:
        """))
        #  Uniflow Campus, Uniflow Access, Uniflow Learn et Uniflow Go.
        self._add_boxes(slide,[
            ("Uniflow Campus","la gestion académique"),
            ("Uniflow Access","la gestion des admissions"),
            ("Uniflow Learn","Relie l’enseignement aux plateformes numériques"),
        ])
    def add_problematique_slide(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide,self.ETUDE_PREALABLE)
        self._add_title(slide,"Problématique")

        # gère les interactions avec les clients,suit les transactions, planifie les tâches de l'équipe et fournit des analyses.
        # Comment intégrer à UniFlow-Suite un module CRM permettant de gérer le cycle de recrutement des candidats ?
        # Comment modéliser le domaine CRM de manière générique afin de faciliter son intégration à la suite existante ?
        # Comment mettre en place un moyen de suivre la performance des campagnes ?
        # Comment permettre à nos utilisateurs de personnaliser les rôles de leurs employés ?

        self._add_boxes(slide,[
            ("Comment intégrer à UniFlow-Suite un module CRM permettant de gérer le cycle de recrutement des candidats ?",""),
            ("Comment modéliser le domaine CRM de manière générique afin de faciliter son intégration à la suite existante ?",""),
            ("Comment mettre en place un moyen de suivre la performance des campagnes ?",""),
            ("Comment permettre à nos utilisateurs de personnaliser les rôles de leurs employés ?","")
        ])

    def add_problematique_slideOLD(self):
        """Slide 4: Problématique (Light Theme with 5-column grid & Conséquence banner)"""
        slide = self._create_slide(self.BG_LIGHT)

        # Top Tag
        tag_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(0.7), Inches(11.5), Inches(0.4))
        p_tag = tag_box.text_frame.paragraphs[0]
        p_tag.text = "ÉTUDE PRÉALABLE"
        p_tag.font.name = self.FONT_MONO
        p_tag.font.size = Pt(13)
        p_tag.font.color.rgb = self.ACCENT_BLUE
        p_tag.font.bold = True

        # Slide Title
        title_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.05), Inches(11.5), Inches(0.8))
        p_title = title_box.text_frame.paragraphs[0]
        p_title.text = "Problématique"
        p_title.font.name = self.FONT_BODY
        p_title.font.bold = True
        p_title.font.size = Pt(36)
        p_title.font.color.rgb = self.TEXT_DARK

        # Main Description Text
        desc_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.9), Inches(11.733), Inches(1.0))
        tf_desc = desc_box.text_frame
        tf_desc.word_wrap = True
        p_desc = tf_desc.paragraphs[0]
        p_desc.text = "L'information client est dispersée entre papier, fichiers Excel et échanges informels. Aucun outil transverse ne pilote la relation commerciale."
        p_desc.font.name = self.FONT_BODY
        p_desc.font.size = Pt(18)
        p_desc.font.color.rgb = self.TEXT_DARK

        # 5 Columns Data
        cols_data = [
            ("01", "Dispersion des informations sur des supports hétérogènes"),
            ("02", "Partage difficile entre commerciaux et intervenants"),
            ("03", "Historique des interactions client impossible à reconstituer"),
            ("04", "Oublis de relances, de rendez-vous et de tâches commerciales"),
            ("05", "Aucune visibilité sur l'avancement des opportunités")
        ]

        col_width = Inches(2.15)
        col_gap = Inches(0.24)
        left_margin = Inches(0.8)
        top_pos = Inches(3.1)

        for i, (num, text) in enumerate(cols_data):
            col_left = left_margin + i * (col_width + col_gap)

            # Top Blue Line
            line = slide.shapes.add_shape(
                MSO_SHAPE.RECTANGLE, col_left, top_pos, col_width, Inches(0.02))
            line.fill.solid()
            line.fill.fore_color.rgb = self.ACCENT_BLUE
            line.line.fill.background()

            # Text box for Column Number & Body
            box = slide.shapes.add_textbox(
                col_left, top_pos + Inches(0.15), col_width, Inches(1.8))
            tf = box.text_frame
            tf.word_wrap = True
            tf.margin_left = tf.margin_right = tf.margin_top = tf.margin_bottom = 0

            p_num = tf.paragraphs[0]
            p_num.text = num
            p_num.font.name = self.FONT_MONO
            p_num.font.size = Pt(12)
            p_num.font.color.rgb = self.TEXT_MUTED_DARK
            p_num.space_after = Pt(6)

            p_txt = tf.add_paragraph()
            p_txt.text = text
            p_txt.font.name = self.FONT_BODY
            p_txt.font.size = Pt(12.5)
            p_txt.font.color.rgb = self.TEXT_DARK

        # Bottom Banner: CONSÉQUENCE
        banner = slide.shapes.add_shape(MSO_SHAPE.RECTANGLE, Inches(
            0.8), Inches(5.25), Inches(11.733), Inches(0.95))
        banner.fill.solid()
        banner.fill.fore_color.rgb = self.BG_DARK
        banner.line.fill.background()

        tf_b = banner.text_frame
        tf_b.word_wrap = True
        tf_b.margin_left = Inches(0.4)
        tf_b.margin_top = Inches(0.28)

        p_b = tf_b.paragraphs[0]

        r_tag = p_b.add_run()
        r_tag.text = "CONSÉQUENCE   "
        r_tag.font.name = self.FONT_MONO
        r_tag.font.size = Pt(12)
        r_tag.font.color.rgb = self.TEXT_MUTED_LIGHT

        r_txt = p_b.add_run()
        r_txt.text = "Perte d'opportunités d'affaires par retard, oubli ou suivi insuffisant."
        r_txt.font.name = self.FONT_BODY
        r_txt.font.size = Pt(16)
        r_txt.font.bold = True
        r_txt.font.color.rgb = self.TEXT_WHITE

    def add_objectifs_slide(self):
        """Slide: Objectifs du projet (Light Theme with 2-column layout: Métier vs Techniques)"""
        slide = self._create_slide(self.BG_LIGHT)

        # Top Tag
        tag_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(0.7), Inches(11.5), Inches(0.4))
        p_tag = tag_box.text_frame.paragraphs[0]
        p_tag.text = "ÉTUDE PRÉALABLE"
        p_tag.font.name = self.FONT_MONO
        p_tag.font.size = Pt(13)
        p_tag.font.color.rgb = self.ACCENT_BLUE
        p_tag.font.bold = True

        # Slide Title
        title_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.05), Inches(11.5), Inches(0.8))
        p_title = title_box.text_frame.paragraphs[0]
        p_title.text = "Objectifs du projet"
        p_title.font.name = self.FONT_BODY
        p_title.font.bold = True
        p_title.font.size = Pt(36)
        p_title.font.color.rgb = self.TEXT_DARK

        # Main Description Text
        desc_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.9), Inches(11.733), Inches(1.0))
        tf_desc = desc_box.text_frame
        tf_desc.word_wrap = True
        p_desc = tf_desc.paragraphs[0]
        p_desc.text = "Doter UniFlow-Suite d'un module CRM moderne, sécurisé et évolutif, intégré aux autres modules de la plateforme."
        p_desc.font.name = self.FONT_BODY
        p_desc.font.size = Pt(18)
        p_desc.font.color.rgb = self.TEXT_DARK

        # Column positions
        left_col_x = Inches(0.8)
        right_col_x = Inches(6.8)
        col_w = Inches(5.633)
        headers_y = Inches(3.1)

        # Left Column Header: OBJECTIFS MÉTIER
        h_box_l = slide.shapes.add_textbox(
            left_col_x, headers_y, col_w, Inches(0.4))
        tf_hl = h_box_l.text_frame
        tf_hl.margin_left = tf_hl.margin_top = tf_hl.margin_right = tf_hl.margin_bottom = 0
        p_hl = tf_hl.paragraphs[0]
        p_hl.text = "OBJECTIFS MÉTIER"
        p_hl.font.name = self.FONT_MONO
        p_hl.font.size = Pt(12)
        p_hl.font.color.rgb = self.TEXT_MUTED_DARK

        # Left Divider Line
        line_l = slide.shapes.add_shape(
            MSO_SHAPE.RECTANGLE, left_col_x, headers_y + Inches(0.35), col_w, Inches(0.01))
        line_l.fill.solid()
        line_l.fill.fore_color.rgb = self.DIVIDER_GRAY
        line_l.line.fill.background()

        # Left Column Items (Métier)
        metier_items = [
            "Centraliser prospects, contacts et organisations dans une plateforme unique",
            "Outiller le cycle commercial, de la qualification du prospect au suivi de l'opportunité",
            "Tracer toutes les interactions pour une vision à 360° de chaque tiers",
            "Fournir tableaux de bord et indicateurs d'aide à la décision"
        ]

        metier_box = slide.shapes.add_textbox(
            left_col_x, headers_y + Inches(0.55), col_w, Inches(2.6))
        tf_m = metier_box.text_frame
        tf_m.word_wrap = True
        tf_m.margin_left = tf_m.margin_top = tf_m.margin_right = tf_m.margin_bottom = 0

        for i, text in enumerate(metier_items):
            p = tf_m.paragraphs[0] if i == 0 else tf_m.add_paragraph()
            p.space_after = Pt(12)

            r_dash = p.add_run()
            r_dash.text = "—  "
            r_dash.font.name = self.FONT_MONO
            r_dash.font.bold = True
            r_dash.font.size = Pt(14)
            r_dash.font.color.rgb = self.ACCENT_BLUE

            r_txt = p.add_run()
            r_txt.text = text
            r_txt.font.name = self.FONT_BODY
            r_txt.font.size = Pt(14)
            r_txt.font.color.rgb = self.TEXT_DARK

        # Right Column Header: OBJECTIFS TECHNIQUES
        h_box_r = slide.shapes.add_textbox(
            right_col_x, headers_y, col_w, Inches(0.4))
        tf_hr = h_box_r.text_frame
        tf_hr.margin_left = tf_hr.margin_top = tf_hr.margin_right = tf_hr.margin_bottom = 0
        p_hr = tf_hr.paragraphs[0]
        p_hr.text = "OBJECTIFS TECHNIQUES"
        p_hr.font.name = self.FONT_MONO
        p_hr.font.size = Pt(12)
        p_hr.font.color.rgb = self.TEXT_MUTED_DARK

        # Right Divider Line
        line_r = slide.shapes.add_shape(
            MSO_SHAPE.RECTANGLE, right_col_x, headers_y + Inches(0.35), col_w, Inches(0.01))
        line_r.fill.solid()
        line_r.fill.fore_color.rgb = self.DIVIDER_GRAY
        line_r.line.fill.background()

        # Right Column Items (Techniques)
        tech_items = [
            ("T1", "Sécurité générique par rôles et permissions (RBAC)"),
            ("T2", "Audit générique de toutes les créations, modifications et suppressions"),
            ("T3", "Architecture extensible à de nouveaux types de clients et d'activités"),
            ("T4", "Sécurité, cohérence et intégrité des données")
        ]

        tech_box = slide.shapes.add_textbox(
            right_col_x, headers_y + Inches(0.55), col_w, Inches(2.6))
        tf_t = tech_box.text_frame
        tf_t.word_wrap = True
        tf_t.margin_left = tf_t.margin_top = tf_t.margin_right = tf_t.margin_bottom = 0

        for i, (tag, text) in enumerate(tech_items):
            p = tf_t.paragraphs[0] if i == 0 else tf_t.add_paragraph()
            p.space_after = Pt(12)

            r_tag = p.add_run()
            r_tag.text = f"{tag}  "
            r_tag.font.name = self.FONT_MONO
            r_tag.font.bold = True
            r_tag.font.size = Pt(14)
            r_tag.font.color.rgb = self.ACCENT_BLUE

            r_txt = p.add_run()
            r_txt.text = text
            r_txt.font.name = self.FONT_BODY
            r_txt.font.size = Pt(14)
            r_txt.font.color.rgb = self.TEXT_DARK

    def add_generic_picture_slide(self, secname: str, picname: str, picpath: str):
        """Slide: Le modèle du domaine (Light Theme with Diagram Placeholder & 3 Structuring Abstractions)"""
        # picpath = f"/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/{picpath}"
        slide = self._create_slide(self.BG_LIGHT)

        # Top Tag
        tag_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(0.7), Inches(11.5), Inches(0.4))
        p_tag = tag_box.text_frame.paragraphs[0]
        p_tag.text = secname
        p_tag.font.name = self.FONT_MONO
        p_tag.font.size = Pt(13)
        p_tag.font.color.rgb = self.ACCENT_BLUE
        p_tag.font.bold = True

        # Slide Title
        title_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.05), Inches(11.5), Inches(0.8))
        p_title = title_box.text_frame.paragraphs[0]
        p_title.text = picname
        p_title.font.name = self.FONT_BODY
        p_title.font.bold = True
        p_title.font.size = Pt(36)
        p_title.font.color.rgb = self.TEXT_DARK

        # Left Diagram Placeholder Card
        # left_pos, top_pos, width_pos, height_pos = Inches(3), Inches(2.1), Inches(7.2), Inches(4.0)
        left_pos, top_pos, width_pos, height_pos = Inches(
            2), Inches(2.1), Inches(7.2*1.3), Inches(4.0*1.3)
        if picpath:
            # Adds PNG or JPEG image directly
            _ = slide.shapes.add_picture(
                picpath, left=left_pos, top=top_pos, width=width_pos, height=height_pos)
        else:
            # Fallback Blank Card Placeholder
            diagram_card = slide.shapes.add_shape(
                MSO_SHAPE.RECTANGLE, left_pos, top_pos, width_pos, height_pos)
            diagram_card.fill.solid()
            diagram_card.fill.fore_color.rgb = self.CARD_WHITE
            diagram_card.line.color.rgb = self.DIVIDER_GRAY

    def add_generic_titleonly_divider_slide(self, title: str):
        """Slide 4: Section Divider - Étude préalable (Dark Theme with Bulleted Breakdown)"""
        slide = self._create_slide(self.BG_DARK)

        # Accent Line
        bar = slide.shapes.add_shape(MSO_SHAPE.RECTANGLE, Inches(
            1.2), Inches(1.3), Inches(1.2), Inches(0.05))
        bar.fill.solid()
        bar.fill.fore_color.rgb = self.ACCENT_BLUE
        bar.line.fill.background()

        # Section Header Container
        container = slide.shapes.add_textbox(
            Inches(1.2), Inches(1.6), Inches(11.0), Inches(5.2))
        tf = container.text_frame
        tf.word_wrap = True
        tf.margin_left = tf.margin_right = tf.margin_top = tf.margin_bottom = 0

        # Title
        p_title = tf.paragraphs[0]
        p_title.text = title
        p_title.font.name = self.FONT_MONO
        p_title.font.bold = True
        p_title.font.size = Pt(44)
        p_title.font.color.rgb = self.TEXT_WHITE
        p_title.alignment = PP_PARAGRAPH_ALIGNMENT.CENTER
        # p_title.space_after = Pt(28)

    def add_generic_divider_slide(self, title: str, bullet_items):
        """Slide 4: Section Divider - Étude préalable (Dark Theme with Bulleted Breakdown)"""
        slide = self._create_slide(self.BG_DARK)

        # Accent Line
        bar = slide.shapes.add_shape(MSO_SHAPE.RECTANGLE, Inches(
            1.2), Inches(1.3), Inches(1.2), Inches(0.05))
        bar.fill.solid()
        bar.fill.fore_color.rgb = self.ACCENT_BLUE
        bar.line.fill.background()

        # Section Header Container
        container = slide.shapes.add_textbox(
            Inches(1.2), Inches(1.6), Inches(11.0), Inches(5.2))
        tf = container.text_frame
        tf.word_wrap = True
        tf.margin_left = tf.margin_right = tf.margin_top = tf.margin_bottom = 0

        # Title
        p_title = tf.paragraphs[0]
        p_title.text = title
        p_title.font.name = self.FONT_MONO
        p_title.font.bold = True
        p_title.font.size = Pt(44)
        p_title.font.color.rgb = self.TEXT_WHITE
        p_title.space_after = Pt(28)

        # Bulleted Items with detailed descriptions

        for label, desc in bullet_items:
            p = tf.add_paragraph()
            p.space_after = Pt(16)

            # Bullet Accent Icon
            run_bullet = p.add_run()
            run_bullet.text = "•  "
            run_bullet.font.name = self.FONT_MONO
            run_bullet.font.bold = True
            run_bullet.font.size = Pt(18)
            run_bullet.font.color.rgb = self.ACCENT_BLUE

            # Label Header
            run_label = p.add_run()
            run_label.text = label
            run_label.font.name = self.FONT_MONO
            run_label.font.bold = True
            run_label.font.size = Pt(17)
            run_label.font.color.rgb = self.TEXT_WHITE

            # Description Detail
            run_desc = p.add_run()
            run_desc.text = desc
            run_desc.font.name = self.FONT_BODY
            run_desc.font.size = Pt(16)
            run_desc.font.color.rgb = self.TEXT_MUTED_LIGHT

    def add_etude_prealable_divider_slide(self):
        title = "Étude préalable"
        bullet_items = [
            ("1: ", "Presentation De L'Organisme"),
            ("2: ", "Le Problematique"),
            ("3: ", "Les Objectifs"),
            ("4: ", "Presentation De L'Organisme"),
        ]
        self.add_generic_divider_slide(title, bullet_items)

    def add_analyse_divider_slide(self):
        title = "Analyse des besoins"
        bullet_items = [
            ("1 : ", "Les Diagrammes De Cas D'Utilisation"),
            ("2 : ", "Les Diagrammes D'Activites"),
        ]
        self.add_generic_divider_slide(title, bullet_items)

    def add_conception_divider_slide(self):
        title = "Conception"
        bullet_items = [
            ("1 : ", "Les Diagrammes De Sequence"),
            ("2 : ", "Le Diagramme De Classe"),
            ("3 : ", "Model Logique Des Donnees"),
        ]
        self.add_generic_divider_slide(title, bullet_items)

    def add_realisation_divider_slide(self):
        title = "Réalisation"
        bullet_items = [
            ("1 : ", "Les Languages De Programmation"),
            ("2 : ", "Les IDEs Utilisees"),
            ("3 : ", "Le SGBD"),
            ("4 : ", "L'Architecture"),
            ("5 : ", "Les Captures D'Ecran"),
        ]
        self.add_generic_divider_slide(title, bullet_items)











    def add_define_campaignes(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide,self.ANALYSE)
        self._add_title(slide,"Les Campagnes")
        self._add_paragraph(slide, STRING("""
            C’est une initiative marketing ou commerciale planifiée visant à atteindre un objectif précis
            sur une période déterminée. Elle est définie par une date de début, une date de fin, un budget et
            des attentes. Tout au long de son exécution, le système suit les gains et les compare aux
            objectifs fixés afin d'évaluer les performances et le retour sur investissement de la campagne.
            """))
    def add_define_clients(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide,self.ANALYSE)
        self._add_title(slide,"Les Clients")
        self._add_paragraph(slide, STRING("""
            Un client est toute personne (physique ou morale) qui a, ou souhaite avoir, une offre auprès de
            nous. C'est pour ça que nous avons décidé de répartir nos clients en trois catégories distinctes.
            """))
        self._add_boxes(slide,[
            ("Prospects", "les personnes qui manifestent de l'intérêt pour nos services"),
            ("Contacts", "les personnes qui ayant déjà bénéficié de nos services"),
            ("Comptes", "les clients stratégiques ou bien des entreprises")
        ])
    def add_define_contacts(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide,self.ANALYSE)
        self._add_title(slide,"Les Contacts")
        self._add_paragraph(slide, STRING("""
            Les contacts sont les personnes qui ayant déjà bénéficié de nos services
            """))
    def add_define_leads(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide,self.ANALYSE)
        self._add_title(slide,"Les Prospects")
        self._add_paragraph(slide, STRING("""
            Les prospects sont des personnes qui manifestent de l'intérêt pour nos services
            """))
    def add_define_accounts(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide,self.ANALYSE)
        self._add_title(slide,"Les Comptes")
        self._add_paragraph(slide, STRING("""
            Le comptes sont des clients stratégiques ou bien des entreprises
            """))
    def add_define_opportunities(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide,self.ANALYSE)
        self._add_title(slide,"Les Opportunities")
        self._add_paragraph(slide, STRING("""
            Les opportunités sont des offres que nous présentons à nos clients
            ils peuvent etre des achats potentiels, une service etc...
            """))
    def add_define_activities(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide,self.ANALYSE)
        self._add_title(slide,"Les Activities")
        self._add_paragraph(slide, STRING("""
            Les activités correspondent à toute action que nous prévoyons d'effectuer
        """))
        self._add_boxes(slide,[
            ("Les taches","sont des actions physiques"),
            ("Les reunions","peuvent etre presentielles ou online"),
            ("Les appels","peuvent etre telephonic ou video")
        ])

    def add_define_extras(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide,self.ANALYSE)
        self._add_title(slide,"fonctionnalités supplémentaires")
        self._add_boxes(slide,[
            ("les notes", "sont de simples remarques"),
            ("les emails", "les courriers électroniques")
        ])

    def add_define_actors(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide,self.ANALYSE)
        self._add_title(slide,"Les Acteurs")
        self._add_boxes(slide,[
            ("Marketeur","Ajoute des clients et des campagnes et des opportunites"),
            ("Directeur","Cloture les opportunites et consulte les rapports"),
            ("Support","Plannifier des activites pour l'equipe"),
            ("Admin","gere les utilisateurs et les authorizations")
        ])










    def add_screenshot_divider_slide(self):
        title = "Les Captures D'ecran"
        bullet_items = [
            # ("Contexte : ", "Présentation de l'organisme d'accueil ITComp et intégration à la plateforme UniFlow-Suite.")
        ]
        self.add_generic_divider_slide(title, bullet_items)

    def add_conclusion_divider_slide(self):
        title = "Conclusion"
        bullet_items = [
            ("1 : ", "Ce que ce projet apporte"),
            ("2 : ", "Difficultés rencontrées"),
            ("3 : ", "Prespective Futur")
        ]
        self.add_generic_divider_slide(title, bullet_items)

    def add_project_apporte_slide(self):
        """Slide 5: Conclusion / Ce que ce projet apporte (Dark Theme)"""
        slide = self._create_slide(self.BG_LIGHT)

        # Top Category Tag
        tag_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(0.7), Inches(11.5), Inches(0.4))
        p_tag = tag_box.text_frame.paragraphs[0]
        p_tag.text = "CONCLUSION"
        p_tag.font.name = self.FONT_MONO
        p_tag.font.size = Pt(13)
        p_tag.font.color.rgb = self.ACCENT_BLUE
        p_tag.font.bold = True

        # Main Title
        title_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.1), Inches(11.5), Inches(0.8))
        p_title = title_box.text_frame.paragraphs[0]
        p_title.text = "Ce que ce projet apporte"
        p_title.font.name = self.FONT_BODY
        p_title.font.bold = True
        p_title.font.size = Pt(36)
        p_title.font.color.rgb = self.TEXT_DARK

        # 3 Column Content Data
        cols_data = [
            {
                "header": "CHERCHÉ À FAIRE",
                "body": "Doter UniFlow-Suite d'un CRM moderne, sécurisé et évolutif, hébergeable en Algérie",
                "top_line_color": self.TEXT_MUTED_DARK,
                "header_color": self.TEXT_SUBTITLE_DARK,
                "has_bottom_blue_bar": True
            },
            {
                "header": "RÉALISÉ",
                "body": "Une application web complète couvrant le cycle commercial, les activités, l'audit et les analytiques",
                "top_line_color": self.TEXT_MUTED_DARK,
                "header_color": self.TEXT_SUBTITLE_DARK,
                "has_bottom_blue_bar": False
            },
            {
                "header": "OBTENU",
                "body": "Quatre objectifs techniques atteints et démontrables, objectifs métier outillés",
                "top_line_color": self.ACCENT_BLUE,
                "header_color": self.ACCENT_BLUE,
                "has_bottom_blue_bar": False
            }
        ]

        col_width = Inches(3.6)
        col_gap = Inches(0.4)
        left_margin = Inches(0.8)
        top_pos = Inches(2.2)

        for i, col in enumerate(cols_data):
            col_left = left_margin + i * (col_width + col_gap)

            # Top Line Divider
            line = slide.shapes.add_shape(
                MSO_SHAPE.RECTANGLE, col_left, top_pos, col_width, Inches(0.015))
            line.fill.solid()
            line.fill.fore_color.rgb = col["top_line_color"]
            line.line.fill.background()

            # Column Header & Text Box
            box = slide.shapes.add_textbox(
                col_left, top_pos + Inches(0.2), col_width, Inches(1.8))
            tf = box.text_frame
            tf.word_wrap = True
            tf.margin_left = tf.margin_top = tf.margin_right = tf.margin_bottom = 0

            p_h = tf.paragraphs[0]
            p_h.text = col["header"]
            p_h.font.name = self.FONT_MONO
            p_h.font.size = Pt(12)
            p_h.font.color.rgb = col["header_color"]
            p_h.space_after = Pt(10)

            p_b = tf.add_paragraph()
            p_b.text = col["body"]
            p_b.font.name = self.FONT_BODY
            p_b.font.size = Pt(13.5)
            p_b.font.color.rgb = self.TEXT_DARK

            # Optional Bottom Accent Bar under Column 1
            if col["has_bottom_blue_bar"]:
                bar = slide.shapes.add_shape(
                    MSO_SHAPE.RECTANGLE, col_left, top_pos + Inches(1.9), Inches(1.5), Inches(0.03))
                bar.fill.solid()
                bar.fill.fore_color.rgb = self.ACCENT_BLUE
                bar.line.fill.background()

        # Bottom Value Proposition Statement
        val_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(4.6), Inches(11.5), Inches(1.6))
        tf_val = val_box.text_frame
        tf_val.word_wrap = True
        tf_val.margin_left = tf_val.margin_top = tf_val.margin_right = tf_val.margin_bottom = 0
        p_val = tf_val.paragraphs[0]
        p_val.text = "Valeur ajoutée : un module intégré à un écosystème existant, hébergé en Algérie, porté par une architecture qui absorbera les évolutions sans être réécrite."
        p_val.font.name = self.FONT_BODY
        p_val.font.size = Pt(22)
        p_val.font.color.rgb = self.TEXT_DARK

    def add_languages_slide(self):
        """Slide: Perspectives futures (Light Theme with 2x2 White Cards Grid)"""
        slide = self._create_slide(self.BG_LIGHT)

        # Top Tag
        tag_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(0.7), Inches(11.5), Inches(0.4))
        p_tag = tag_box.text_frame.paragraphs[0]
        p_tag.text = "BILAN"
        p_tag.font.name = self.FONT_MONO
        p_tag.font.size = Pt(13)
        p_tag.font.color.rgb = self.ACCENT_BLUE
        p_tag.font.bold = True

        # Slide Title
        title_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.05), Inches(11.5), Inches(0.8))
        p_title = title_box.text_frame.paragraphs[0]
        p_title.text = "Les Languages et outils"
        p_title.font.name = self.FONT_BODY
        p_title.font.bold = True
        p_title.font.size = Pt(36)
        p_title.font.color.rgb = self.TEXT_DARK

        # Cards Data
        cards_data = [
            (
                "",
                "ASP.NET Core",
                "un framework développé pour créer des applications web en C#.",
                Inches(0.8), Inches(2.1)
            ),
            (
                "",
                "Angular",
                "un framework web frontend permettant de créer des SPA.",
                Inches(6.8), Inches(2.1)
            ),
            (
                "",
                "SQL Server",
                "un SGBDR développé par Microsoft.",
                Inches(6.8), Inches(2.1)
            ),
        ]

        card_w = Inches(5.733)
        card_h = Inches(1.8)

        for num, title, body, left, top in cards_data:
            # White Card Background
            card = slide.shapes.add_shape(
                MSO_SHAPE.RECTANGLE, left, top, card_w, card_h)
            card.fill.solid()
            card.fill.fore_color.rgb = self.CARD_WHITE
            card.line.fill.background()

            # Top Accent Blue Border Line
            accent_bar = slide.shapes.add_shape(
                MSO_SHAPE.RECTANGLE, left, top, card_w, Inches(0.04))
            accent_bar.fill.solid()
            accent_bar.fill.fore_color.rgb = self.ACCENT_BLUE
            accent_bar.line.fill.background()

            # Text frame inside card
            tf = card.text_frame
            tf.word_wrap = True
            tf.margin_left = Inches(0.3)
            tf.margin_right = Inches(0.3)
            tf.margin_top = Inches(0.2)
            tf.margin_bottom = Inches(0.2)

            # Number (e.g., 01)
            p_num = tf.paragraphs[0]
            p_num.text = num
            p_num.font.name = self.FONT_MONO
            p_num.font.size = Pt(12)
            p_num.font.color.rgb = self.ACCENT_BLUE
            p_num.space_after = Pt(4)

            # Title
            p_t = tf.add_paragraph()
            p_t.text = title
            p_t.font.name = self.FONT_BODY
            p_t.font.bold = True
            p_t.font.size = Pt(16)
            p_t.font.color.rgb = self.TEXT_DARK
            p_t.space_after = Pt(6)

            # Body text
            p_b = tf.add_paragraph()
            p_b.text = body
            p_b.font.name = self.FONT_BODY
            p_b.font.size = Pt(12.5)
            p_b.font.color.rgb = self.TEXT_MUTED_DARK

    def add_difficultes_slide(self):
        """Slide: Difficultés rencontrées et arbitrages (Light Theme with 3 Columns)"""
        slide = self._create_slide(self.BG_LIGHT)

        # Top Tag
        tag_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(0.7), Inches(11.5), Inches(0.4))
        p_tag = tag_box.text_frame.paragraphs[0]
        p_tag.text = "BILAN"
        p_tag.font.name = self.FONT_MONO
        p_tag.font.size = Pt(13)
        p_tag.font.color.rgb = self.ACCENT_BLUE
        p_tag.font.bold = True

        # Slide Title
        title_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.05), Inches(11.5), Inches(0.8))
        p_title = title_box.text_frame.paragraphs[0]
        p_title.text = "Difficultés rencontrées "
        p_title.font.name = self.FONT_BODY
        p_title.font.bold = True
        p_title.font.bold = True
        p_title.font.color.rgb = self.TEXT_DARK

        # Column Data
        cols_data = [
            {
                "num": "Difficulté 1",
                "title": "Apprendre le stack",
                "desc": "ITcomp a utilisé ABP et Angular, deux frameworks que j'ai dû apprendre pour réaliser le projet.",
                "arbitrage": "Application réservée aux équipes marketing : le client garde son canal, l'outil centralise le suivi."
            },
            {
                "num": "Difficulté 2",
                "title": "La production d’un code propre",
                "desc": "ULa production d’un code propreutorité reconnue n'a pas pu être acquis dans le cadre du projet.",
                "arbitrage": "Certificat auto-signé : les échanges sont chiffrés, mais le navigateur affiche un avertissement."
            }
            # ,
            # {
            #     "num": "Difficulté 3",
            #     "title": "Service d'envoi d'e-mails",
            #     "desc": "Une adresse par utilisateur exigerait que chacun possède et configure un compte Google.",
            #     "arbitrage": "Une seule adresse Gmail dédiée à l'application pour l'ensemble des envois."
            # }
        ]

        col_width = Inches(3.64)
        col_gap = Inches(0.4)
        left_margin = Inches(0.8)

        for i, data in enumerate(cols_data):
            col_left = left_margin + i * (col_width + col_gap)

            # Top Section Text Box (Difficulté + Title + Desc)
            top_box = slide.shapes.add_textbox(
                col_left, Inches(2.1), col_width, Inches(2.2))
            tf_top = top_box.text_frame
            tf_top.word_wrap = True
            tf_top.margin_left = tf_top.margin_top = tf_top.margin_right = tf_top.margin_bottom = 0

            # Difficulty Tag
            p_num = tf_top.paragraphs[0]
            p_num.text = data["num"]
            p_num.font.name = self.FONT_MONO
            p_num.font.size = Pt(12)
            p_num.font.color.rgb = self.ACCENT_BLUE
            p_num.space_after = Pt(8)

            # Title
            p_t = tf_top.add_paragraph()
            p_t.text = data["title"]
            p_t.font.name = self.FONT_BODY
            p_t.font.bold = True
            p_t.font.size = Pt(18)
            p_t.font.color.rgb = self.TEXT_DARK
            p_t.space_after = Pt(8)

            # Description
            p_d = tf_top.add_paragraph()
            p_d.text = data["desc"]
            p_d.font.name = self.FONT_BODY
            p_d.font.size = Pt(13)
            p_d.font.color.rgb = self.TEXT_MUTED_DARK

            # Divider Line
            # line = slide.shapes.add_shape(
            #     MSO_SHAPE.RECTANGLE, col_left, Inches(4.5), col_width, Inches(0.015))
            # line.fill.solid()
            # line.fill.fore_color.rgb = self.ACCENT_BLUE
            # line.line.fill.background()

            # Bottom Section Text Box (Arbitrage)
            # bot_box = slide.shapes.add_textbox(
            #     col_left, Inches(4.7), col_width, Inches(1.5))
            # tf_bot = bot_box.text_frame
            # tf_bot.word_wrap = True
            # tf_bot.margin_left = tf_bot.margin_top = tf_bot.margin_right = tf_bot.margin_bottom = 0
            #
            # # ARBITRAGE Tag
            # p_arb_tag = tf_bot.paragraphs[0]
            # p_arb_tag.text = "ARBITRAGE"
            # p_arb_tag.font.name = self.FONT_MONO
            # p_arb_tag.font.size = Pt(11)
            # p_arb_tag.font.color.rgb = self.TEXT_MUTED_DARK
            # p_arb_tag.space_after = Pt(6)
            #
            # # Arbitrage Text
            # p_arb_txt = tf_bot.add_paragraph()
            # p_arb_txt.text = data["arbitrage"]
            # p_arb_txt.font.name = self.FONT_BODY
            # p_arb_txt.font.size = Pt(13)
            # p_arb_txt.font.color.rgb = self.TEXT_DARK
            #
    def add_perspectives_slide(self):
        """Slide: Perspectives futures (Light Theme with 2x2 White Cards Grid)"""
        slide = self._create_slide(self.BG_LIGHT)

        # Top Tag
        tag_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(0.7), Inches(11.5), Inches(0.4))
        p_tag = tag_box.text_frame.paragraphs[0]
        p_tag.text = "BILAN"
        p_tag.font.name = self.FONT_MONO
        p_tag.font.size = Pt(13)
        p_tag.font.color.rgb = self.ACCENT_BLUE
        p_tag.font.bold = True

        # Slide Title
        title_box = slide.shapes.add_textbox(
            Inches(0.8), Inches(1.05), Inches(11.5), Inches(0.8))
        p_title = title_box.text_frame.paragraphs[0]
        p_title.text = "Perspectives"
        p_title.font.name = self.FONT_BODY
        p_title.font.bold = True
        p_title.font.size = Pt(36)
        p_title.font.color.rgb = self.TEXT_DARK

        # Cards Data
        cards_data = [
            (
                "01",
                "L'integration avec les reseaux sociaux",
                "Envoi en masse de messages personnalisés, offres ciblées, reconquête des clients inactifs",
                Inches(0.8), Inches(2.1)
            ),
            (
                "02",
                "Intelligence artificielle",
                "Identification des clients à traiter en priorité pour mieux répartir l'effort commercial",
                Inches(6.8), Inches(2.1)
            ),

        ]

        card_w = Inches(5.733)
        card_h = Inches(1.8)

        for num, title, body, left, top in cards_data:
            # White Card Background
            card = slide.shapes.add_shape(
                MSO_SHAPE.RECTANGLE, left, top, card_w, card_h)
            card.fill.solid()
            card.fill.fore_color.rgb = self.CARD_WHITE
            card.line.fill.background()

            # Top Accent Blue Border Line
            accent_bar = slide.shapes.add_shape(
                MSO_SHAPE.RECTANGLE, left, top, card_w, Inches(0.04))
            accent_bar.fill.solid()
            accent_bar.fill.fore_color.rgb = self.ACCENT_BLUE
            accent_bar.line.fill.background()

            # Text frame inside card
            tf = card.text_frame
            tf.word_wrap = True
            tf.margin_left = Inches(0.3)
            tf.margin_right = Inches(0.3)
            tf.margin_top = Inches(0.2)
            tf.margin_bottom = Inches(0.2)

            # Number (e.g., 01)
            p_num = tf.paragraphs[0]
            p_num.text = num
            p_num.font.name = self.FONT_MONO
            p_num.font.size = Pt(12)
            p_num.font.color.rgb = self.ACCENT_BLUE
            p_num.space_after = Pt(4)

            # Title
            p_t = tf.add_paragraph()
            p_t.text = title
            p_t.font.name = self.FONT_BODY
            p_t.font.bold = True
            p_t.font.size = Pt(16)
            p_t.font.color.rgb = self.TEXT_DARK
            p_t.space_after = Pt(6)

            # Body text
            p_b = tf.add_paragraph()
            p_b.text = body
            p_b.font.name = self.FONT_BODY
            p_b.font.size = Pt(12.5)
            p_b.font.color.rgb = self.TEXT_MUTED_DARK

    def add_define_crm(self):
        slide = self._create_slide(self.BG_LIGHT)
        self._add_top_tag(slide,self.ANALYSE)
        self._add_title(slide,"C'est Quoi Un CRM")
        self._add_paragraph(slide, STRING("""
            Le CRM (Customer Relationship Management) est un logiciel qui:
            """))
        # gère les interactions avec les clients,suit les transactions, planifie les tâches de l'équipe et fournit des analyses.
        self._add_boxes(slide,[
            ("gère les interactions avec les clients",""),
            ("suit les offres",""),
            ("planifie les tâches de l'équipe",""),
            ("fournit des analyses","")
        ])
        pass
    def _add_boxes(self, slide, cards_data):
        # cards_data = [
        #     (
        #         "L'integration avec les reseaux sociaux",
        #         "Envoi en masse de messages personnalisés, offres ciblées, reconquête des clients inactifs",
        #     )
        # ]

        card_w = Inches(5.733)
        card_h = Inches(1.8)
        for title, body in cards_data:
            # White Card Background
            card = slide.shapes.add_shape(
                MSO_SHAPE.RECTANGLE, Inches(0.8), Inches(2.1), card_w, card_h)
            card.fill.solid()
            card.fill.fore_color.rgb = self.CARD_WHITE
            card.line.fill.background()

            # Top Accent Blue Border Line
            accent_bar = slide.shapes.add_shape(
                MSO_SHAPE.RECTANGLE, Inches(0.8), Inches(2.1), card_w, Inches(0.04))
            accent_bar.fill.solid()
            accent_bar.fill.fore_color.rgb = self.ACCENT_BLUE
            accent_bar.line.fill.background()

            # Text frame inside card
            tf = card.text_frame
            tf.word_wrap = True
            tf.margin_left = Inches(0.3)
            tf.margin_right = Inches(0.3)
            tf.margin_top = Inches(0.2)
            tf.margin_bottom = Inches(0.2)
            # Title
            p_t = tf.add_paragraph()
            p_t.text = title
            p_t.font.name = self.FONT_BODY
            p_t.font.bold = True
            p_t.font.size = Pt(16)
            p_t.font.color.rgb = self.TEXT_DARK
            p_t.space_after = Pt(6)

            # Body text
            p_b = tf.add_paragraph()
            p_b.text = body
            p_b.font.name = self.FONT_BODY
            p_b.font.size = Pt(12.5)
            p_b.font.color.rgb = self.TEXT_MUTED_DARK









def main():
    deck = UniFlowDeck("my-presentation.pptx")

    # =============================

    deck.add_title_slide()

    # =============================
    # Présentation du sujet
    deck.add_plan_slide()
    deck.add_etude_prealable_divider_slide()
    deck.add_organisme_slide()
    deck.add_organisme_slide2()
    # Uniflow
    deck.add_uniflow_slide()
    # Problématique
    deck.add_problematique_slide()
    # Objectifs
    deck.add_objectifs_slide()

    deck.add_analyse_divider_slide()


    #- [ ] define a CRM
    deck.add_define_crm()
    #  Campagnes
    deck.add_define_campaignes()
    #  Clients and their types (persons, companies)
    deck.add_define_clients()
    #  - Contacts
    # deck.add_define_contacts()
    #  - leads and their cycle
    # deck.add_define_leads()
    #  - Accounts
    # deck.add_define_accounts()
    #  - Opportunities
    deck.add_define_opportunities()
    #  - activities
    deck.add_define_activities()
    #  - extras
    deck.add_define_extras()
    #  - actors
    deck.add_define_actors()
    #  - Marketeur, Directeur, Support
    #  - Admin, User





    # Diagramme de cas d’utilisation général
    deck.add_generic_titleonly_divider_slide(
        title="Les Diagrammes De Cas D'Utilisation")
    deck.add_generic_picture_slide(picname="Global", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/unfinished/jpg/global!global_1.jpg")
    # Présentation d’un Diagramme de cas d’utilisation
    deck.add_generic_picture_slide(picname="Authentification", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/unfinished/jpg/authentification!authentification_2.jpg")
    deck.add_generic_picture_slide(picname="Clients", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/unfinished/jpg/clients!clients_4.jpg")
    deck.add_generic_picture_slide(picname="Activities", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/unfinished/jpg/activities!activities_3.jpg")
    deck.add_generic_picture_slide(picname="Opportunites", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/unfinished/jpg/opportunites!opportunites_5.jpg")
    deck.add_generic_picture_slide(picname="Campagnes", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/unfinished/jpg/campagne!campagnr_6.jpg")
    deck.add_generic_picture_slide(picname="Analytiques", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/unfinished/jpg/analytics!analytics_7.jpg")
    deck.add_generic_picture_slide(picname="Administration", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/unfinished/jpg/administration!administration_8.jpg")

    # Présentation d’un Diagramme d’activité (le même processus que celui du diagramme UC) ADD CONVERT LEAD
    deck.add_generic_titleonly_divider_slide(title="Les Diagrammes D'Activite")
    deck.add_generic_picture_slide(picname="Authentification", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/auth.png")
    deck.add_generic_picture_slide(picname="Modification de Prospect", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/prospect-update.png")
    deck.add_generic_picture_slide(picname="Qualification de Prospect", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/leadqual.png")
    deck.add_generic_picture_slide(picname="Conversion de Prospect", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/leadconvert.png")
    deck.add_generic_picture_slide(picname="Cloture D'Opportunite", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/opportunity-close.png")
    deck.add_generic_picture_slide(picname="Modification de Note", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/notes-edit.png")
    deck.add_generic_picture_slide(picname="Modification D'Opportunite", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/opportunity-modify.png")
    deck.add_generic_picture_slide(picname="Activation De Campagne", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/campagne-activate.png")
    deck.add_generic_picture_slide(picname="Disactivation De Campagne", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/campagne-deactive.png")
    deck.add_generic_picture_slide(picname="Creation D'une Tache", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/task-create.png")
    deck.add_generic_picture_slide(picname="Envoi de Mail", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/email-send.png")
    deck.add_generic_picture_slide(picname="Affectation Des Roles", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/role-assign.png")
    deck.add_generic_picture_slide(picname="Affectation Des Permissions", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/perms-assign.png")
    deck.add_generic_picture_slide(picname="Analytiques De Prospect", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/analytics-prospects.png")
    deck.add_generic_picture_slide(picname="Analytiques De Contacts", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/analytics-contacts.png")
    deck.add_generic_picture_slide(picname="Analytiques De Compte", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/analytics-accounts.png")
    deck.add_generic_picture_slide(picname="analytiques D'Opportunite", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/analytics-opp.png")
    deck.add_generic_picture_slide(picname="Analytiques De Campagne", secname="L'Analyse Des Besoins",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/act/analytics-campagne.png")

    deck.add_conception_divider_slide()
    deck.add_generic_titleonly_divider_slide(
        title="Les Diagrammes De Sequence")
    # Présentation d’un Diagramme de séquence (le même processus que celui du diagramme UC)
    deck.add_generic_picture_slide(picname="L'Inscription", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/signup.png")
    deck.add_generic_picture_slide(picname="Authentification", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/login.png")
    deck.add_generic_picture_slide(picname="Consultation Du Profile", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/account-see.png")
    deck.add_generic_picture_slide(picname="Modifier Profile", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/account-edit.png")
    deck.add_generic_picture_slide(picname="Comptes", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/account.png")
    deck.add_generic_picture_slide(picname="Prospects", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/lead.png")
    deck.add_generic_picture_slide(picname="Qualification Des Prospects", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/lead-qualify.png")
    deck.add_generic_picture_slide(picname="Conversion Des Prospects", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/lead-convert.png")
    deck.add_generic_picture_slide(picname="Contacts", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/contact.png")
    deck.add_generic_picture_slide(picname="Opportunites", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/opp.png")
    deck.add_generic_picture_slide(picname="Cloture Des Opportunites", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/opp-close.png")
    deck.add_generic_picture_slide(picname="Campagne", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/campagne.png")
    deck.add_generic_picture_slide(picname="Activation Des Campagnes", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/campagne-activation.png")
    deck.add_generic_picture_slide(picname="Taches", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/tasks.png")
    deck.add_generic_picture_slide(picname="Appels", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/call.png")
    deck.add_generic_picture_slide(picname="Reunions", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/meeting.png")
    deck.add_generic_picture_slide(picname="Notes", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/notes.png")
    deck.add_generic_picture_slide(picname="Emails", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/emails.png")
    deck.add_generic_picture_slide(picname="Envoi De Mails", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/email-send.png")
    deck.add_generic_picture_slide(picname="Utilisateurs", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/users.png")
    deck.add_generic_picture_slide(picname="Roles", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/roles.png")
    deck.add_generic_picture_slide(picname="Affectation Des Permissions", secname="La Conception",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/diagrams/seq/permission-assign.png")
    # Diagramme de classe
    deck.add_generic_picture_slide(picname="Le Diagramme De Classe", secname="La Conception", picpath="/home/sassy/Projects/projetfindetude/main/exporterDiagrams/class/main class diagram.png")
    deck.add_generic_picture_slide(picname="Le Diagramme De Classe", secname="La Conception", picpath="/home/sassy/Projects/projetfindetude/main/exporterDiagrams/class/main class diagram.png")
    deck.add_generic_picture_slide(picname="Le Diagramme De Classe", secname="La Conception", picpath="/home/sassy/Projects/projetfindetude/main/exporterDiagrams/class/main class diagram.png")
    deck.add_generic_picture_slide(picname="Le Diagramme De Classe", secname="La Conception", picpath="/home/sassy/Projects/projetfindetude/main/exporterDiagrams/class/main class diagram.png")
    deck.add_generic_picture_slide(picname="Le Diagramme De Classe", secname="La Conception", picpath="/home/sassy/Projects/projetfindetude/main/exporterDiagrams/class/main class diagram.png")
    deck.add_generic_picture_slide(picname="Le Diagramme De Classe", secname="La Conception", picpath="/home/sassy/Projects/projetfindetude/main/exporterDiagrams/class/main class diagram.png")
    # for full screen
    deck.add_generic_picture_slide(
        picname="", secname="", picpath="/home/sassy/Projects/projetfindetude/main/exporterDiagrams/class/main class diagram.png")

    deck.add_generic_titleonly_divider_slide(
        title="Le Model Logique Des Donnees")
    # Mld
    deck.add_generic_slide(tag="La Conception", title="Model Logique Des Donnees", paragraph="""Leads (Id , FirstName, LastName, Description, Status, Source, Phone, Email, UserID#, AccountID#, CampaignID#, CreationTime, CreatorId#, LastModificationTime, LastModifierId#, IsDeleted, DeleterId#, DeletionTime );
Accounts (Id , Name, Description, Phone, Fax, Email, Website, Street, City, Country, PostalCode, Type, Industry, IncomeValue, IncomeCurrency, Employees, UserID#, CampaignID# , CreationTime, CreatorId#, LastModificationTime, LastModifierId#, IsDeleted, DeleterId#, DeletionTime );
Contacts (Id , FirstName, MiddleName, LastName, Description, Status, Source, Phone, Fax, Email, Website, Street, City, Country, PostalCode, Job, Department, AccountID#, LeadID#, UserID#,  CampaignID#, CreationTime, CreatorId#, LastModificationTime, LastModifierId#, IsDeleted, DeleterId#, DeletionTime );""")

    deck.add_generic_slide(tag="La Conception", title="Model Logique Des Donnees", paragraph="""Opportunities (Id , Name, Description, AmountValue, AmountCurrency, Stage, Type, Probability, NextStep, ClosedAt, AccountID#, ContactID#, LeadID#, OwnerID#, CampaignID#,  CreationTime, CreatorId#, LastModificationTime, LastModifierId#, IsDeleted, DeleterId#, DeletionTime );
Campaign (Id , Name, Description, Status, Budget, CostSoFar, ExpectedAccounts, ExpectedLeads, ExpectedContacts, ExpectedOpportunities, StartDate, EndDate, OwnerID#, CreationTime, CreatorId#, LastModificationTime, LastModifierId#, IsDeleted, DeleterId#, DeletionTime)
        """)
    deck.add_generic_slide(tag="La Conception", title="Model Logique Des Donnees", paragraph="""Calls (Id PK, Name, Description, Status, Direction, StartTime, EndTime, Duration, PhoneNumber, AccountID, ContactID, OpportunityID, LeadID, OwnerID, CreationTime, CreatorId, LastModificationTime, LastModifierId, IsDeleted, DeleterId, DeletionTime );
Meetings (Id, PK Name, Description, Status, StartTime, EndTime, Location, AccountID, ContactID, OpportunityID, LeadID, OwnerID, CreationTime, CreatorId, LastModificationTime, LastModifierId, IsDeleted, DeleterId, DeletionTime );
Tasks (Id PK, Name, Description, Status, Priority, StartTime, EndTime, CompletedAt, AccountID, ContactID, OpportunityID, LeadID, OwnerID, CreationTime, CreatorId, LastModificationTime, LastModifierId, IsDeleted, DeleterId, DeletionTime );""")
    deck.add_generic_slide(tag="La Conception", title="Model Logique Des Donnees", paragraph="""Notes (Id PK, Title, Content, Type, AccountID, ContactID, OpportunityID, LeadID, OwnerID, CreationTime, CreatorId, LastModificationTime, LastModifierId, IsDeleted, DeleterId, DeletionTime );
emails (Id PK, Subject, Body, Status, From, To, Cc, Bcc, SentAt, IsHtml, AccountID, ContactID, OpportunityID, LeadID, OwnerID, CreationTime, CreatorId, LastModificationTime, LastModifierId, IsDeleted, DeleterId, DeletionTime);
        """)
    deck.add_generic_slide(tag="La Conception", title="Model Logique Des Donnees", paragraph="""User (Id PK, username, passwordhash, name, surname, email, phone, CreationTime, CreatorId, LastModificationTime, LastModifierId, IsDeleted, DeleterId, DeletionTime);
Role (Id PK, name);
Permission (Id PK, name);
RoleUser(IdRole PK, IdUser PK)
PermissionGrants(IdPermission PK,IdRole PK,IdUser PK)
    """)

    deck.add_realisation_divider_slide()
    # Outils de développement
    deck.add_languages_slide()
    # Présentation de qlq interfaces (authentification,  page d’accuiel)
    deck.add_generic_titleonly_divider_slide(title="Les Captures D'Ecran")
    # TODO
    deck.add_generic_picture_slide(picname="Details D'un compte", secname="Comptes",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/accountdetails.png")
    deck.add_generic_picture_slide(picname="List Des Comptes", secname="Comptes",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/accountlist.png")
    deck.add_generic_picture_slide(picname="List Des Prospects", secname="Prospects",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/prospectslist.png")
    deck.add_generic_picture_slide(picname="La Qualification D'un Prospect", secname="Prospects",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/qualifyingaprospect.png")
    deck.add_generic_picture_slide(picname="La Conversion D'un Prospect", secname="Prospects",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/convertingaprospect.png")
    deck.add_generic_picture_slide(picname="List Des Contacts", secname="Contacts",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/contactsearch.png")
    deck.add_generic_picture_slide(picname="La Creation D'Une Opportunite", secname="Opportunites",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/creatinganopportunity.png")
    deck.add_generic_picture_slide(picname="Les Details D'Une Opportunite", secname="Opportunites",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/opdetails.png")
    deck.add_generic_picture_slide(picname="Le Cloture D'Une Oppotunite", secname="Opportunites",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/closinganopportunity.png")
    # add campagnes
    deck.add_generic_picture_slide(picname="L'analytique D'Une Campagne", secname="Campagnes",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/campagne.png")
    # add activities
    deck.add_generic_picture_slide(picname="La liste des appels", secname="Activites",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/call.png")
    # add notes
    # add emails
    # add administration
    deck.add_generic_picture_slide(picname="Les roles", secname="Administration",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/roles.png")

    deck.add_generic_picture_slide(picname="Les permissions", secname="Administration",
                                   picpath="/home/sassy/Projects/projetfindetude/helpers/powerpoint/screenshots/perms.png")
    # Conclusion
    deck.add_conclusion_divider_slide()
    # final result
    deck.add_project_apporte_slide()
    # defficulities
    deck.add_difficultes_slide()
    # future prespectives
    deck.add_perspectives_slide()
    deck.save()
