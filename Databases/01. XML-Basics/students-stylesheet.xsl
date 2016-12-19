<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" 
xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
xmlns:exams="https://www.w3.org/exams" 
xmlns:students="https://www.w3.org/students">
    <xsl:output method="html" indent="yes"/>
    <xsl:template match="/">
        <html>
            <body>
                <xsl:for-each select="/students:students/students:student" >
                    <ul>
                        <li>
                            <xsl:value-of select="students:name"></xsl:value-of>
                        </li>
                        <li>
                            <xsl:value-of select="students:sex"></xsl:value-of>
                        </li>
                        <li>
                            <xsl:value-of select="students:birthDate"></xsl:value-of>
                        </li>
                        <li>
                            <xsl:value-of select="students:phone"></xsl:value-of>
                        </li>
                        <li>
                            <xsl:value-of select="students:email"></xsl:value-of>
                        </li>
                        <li>
                            <xsl:value-of select="students:course"></xsl:value-of>
                        </li>
                        <li>
                            <xsl:value-of select="students:specialty"></xsl:value-of>
                        </li>
                        <li>
                            <xsl:value-of select="students:facultyNumber"></xsl:value-of>
                        </li>
                        <li>
                            <ul>
                                <xsl:for-each select="students:exams/exams:exam">
                                    <li>
                                        <xsl:value-of select="exams:name"></xsl:value-of>
                                    </li>
                                    <li>
                                        <xsl:value-of select="exams:tutor"></xsl:value-of>
                                    </li>
                                    <li>
                                        <xsl:value-of select="exams:score"></xsl:value-of>
                                    </li>
                                </xsl:for-each>
                            </ul>
                        </li>
                    </ul>
                </xsl:for-each>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>