<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <html>
      <body>
        <xsl:for-each select="/catalogue/album" >
          <ul>
            <li>
              <xsl:value-of select="name"></xsl:value-of>
            </li>
            <li>
              <xsl:value-of select="artist"></xsl:value-of>
            </li>
            <li>
              <xsl:value-of select="year"></xsl:value-of>
            </li>
            <li>
              <xsl:value-of select="producer"></xsl:value-of>
            </li>
            <li>
              <xsl:value-of select="price"></xsl:value-of>
            </li>
            <li>
              <ul>
                <xsl:for-each select="songs/song">
                  <li>
                    <xsl:value-of select="title"></xsl:value-of>
                  </li>
                  <li>
                    <xsl:value-of select="duration"></xsl:value-of>
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